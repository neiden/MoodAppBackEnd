using System.Data.SqlClient;
using Models;
using Serilog;

namespace DataAccess;

public class DBRepository : IRepo
{

    public bool UpdateUser(Account updated_acc)
    {
        try
        {
            //int user_ID = updated_acc.User_Id;
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
            connection.Open();

            string uquery = "UPDATE USERS SET F_Name = @F_Name, L_Name = @L_Name, Phone_Number = @Phone_Number, Zipcode = @Zipcode, Birthdate = @Birthdate WHERE User_Id = @U_Id";
            using SqlCommand command = new SqlCommand(uquery, connection);
            command.Parameters.AddWithValue("@F_Name", updated_acc.Firstname);
            command.Parameters.AddWithValue("@L_Name", updated_acc.Lastname);
            command.Parameters.AddWithValue("@Phone_Number", updated_acc.PhoneNumber);
            command.Parameters.AddWithValue("@Zipcode", updated_acc.Zipcode);
            command.Parameters.AddWithValue("@Birthdate", updated_acc.Birthdate);
            command.Parameters.AddWithValue("@U_Id", updated_acc.User_Id);

            command.ExecuteNonQuery();

            string lquery = "UPDATE LOGINS SET Username = @username, Pwd = @pwd, Email = @email WHERE U_Id = @uId";
            using SqlCommand cmd = new SqlCommand(lquery, connection);
            cmd.Parameters.AddWithValue("@username", updated_acc.Username);
            cmd.Parameters.AddWithValue("@uId", updated_acc.User_Id);
            cmd.Parameters.AddWithValue("@pwd", updated_acc.Password);
            cmd.Parameters.AddWithValue("@email", updated_acc.Email);

            cmd.ExecuteNonQuery();

            return true;
        }
        catch (SqlException e)
        {
            Log.Error("Update user failed: " + e);
            return false;
            throw e;
        }
    }
    public Users Authenticate(string[] loginInfo)
    {
        Users user = new Users();
        using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
        connection.Open();

        using SqlCommand cmd = new SqlCommand("SELECT User_Id, F_Name, L_Name, Phone_Number, Zipcode, Birthdate FROM Logins JOIN Users on Logins.U_Id = Users.User_Id WHERE Logins.Username = @username AND Logins.Pwd = @pass", connection);
        cmd.Parameters.AddWithValue("@username", loginInfo[0]);
        cmd.Parameters.AddWithValue("@pass", loginInfo[1]);

        using SqlDataReader reader = cmd.ExecuteReader();
        reader.Read();
        if (reader.HasRows)
        {
            user.User_Id = (int)reader["User_Id"];
            user.F_Name = (string)reader["F_Name"];
            user.L_Name = (string)reader["L_Name"];
            user.Phone_Number = (string)reader["Phone_Number"];
            user.Zipcode = (string)reader["Zipcode"];
            user.Birthdate = (DateTime)reader["Birthdate"];
        }

        return user;
    }

    /// <summary>
    /// information for all users
    /// </summary>
    /// <returns> List of all users </returns>
    public List<Users> GetAllUsers()
    {
        List<Users> allUsers = new();

        using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
        connection.Open();

        using SqlCommand command = new("SELECT * FROM USERS", connection);
        using SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            allUsers.Add(new Users(
            (int)reader["User_Id"],
            (string)reader["F_Name"],
            (string)reader["L_Name"],
            (string)reader["Phone_Number"],
            (string)reader["Zipcode"],
            (DateTime)reader["Birthdate"]
            ));
        }
        return allUsers;
    }

    ///<summary>
    ///Data persistence for creating a new user
    ///</summary>

    public Boolean CreateNewUser(Account acc)
    {
        bool success = false;
        try
        {
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
            connection.Open();

            using SqlCommand command = new SqlCommand("INSERT INTO USERS(F_Name, L_Name, Phone_Number, Zipcode, Birthdate) OUTPUT INSERTED.User_Id VALUES(@F_Name, @L_Name, @Phone_Number, @Zipcode, @Birthdate)", connection);
            command.Parameters.AddWithValue("@F_Name", acc.Firstname);
            command.Parameters.AddWithValue("@L_Name", acc.Lastname);
            command.Parameters.AddWithValue("@Phone_Number", acc.PhoneNumber);
            command.Parameters.AddWithValue("@Zipcode", acc.Zipcode);
            command.Parameters.AddWithValue("@Birthdate", acc.Birthdate);

            command.CommandType = System.Data.CommandType.Text;

            var result = command.ExecuteScalar();
            int user_ID;
            if (result != null)
            {
                user_ID = (int)result;
            }
            else
            {
                Log.Error("User_id wasn't created in create user");
                return false;
            }

            using SqlCommand cmd = new SqlCommand("INSERT INTO Logins VALUES(@username, @pHash, @pwd, @uId, @email)", connection);
            cmd.Parameters.AddWithValue("@username", acc.Username);
            cmd.Parameters.AddWithValue("@uId", user_ID);
            cmd.Parameters.AddWithValue("@pHash", "password");
            cmd.Parameters.AddWithValue("@pwd", acc.Password);
            cmd.Parameters.AddWithValue("@email", acc.Email);


            cmd.ExecuteNonQuery();
            success = true;
        }
        catch (SqlException e)
        {
            Log.Error("Error in creating user: " + e);
            throw e;
        }
        return success;
    }

    ///might delete this later?
    public Login? GetUserByUsername(string Username)
    {
        using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
        connection.Open();

        using SqlCommand command = new("SELECT * FROM LOGIN WHERE UPPER(Username) = @Username", connection);
        command.Parameters.AddWithValue("@Username", Username.ToUpper());

        using SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Login login = new Login(
                (string)reader["Username"],
                (string)reader["P_hash_salt"],
                (string)reader["Pwd"],
                (int)reader["U_Id"],
                (string)reader["Email"]
            );
            return login;
        }
        return null;
    }

    public Account? GetAccountByUserID(int U_Id)
    {

        try
        {
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
            connection.Open();

            using SqlCommand command = new("SELECT * FROM Logins JOIN Users ON Logins.U_Id = Users.User_Id WHERE Users.User_Id = @UserId", connection);
            command.Parameters.AddWithValue("@UserId", U_Id);

            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Account acc = new Account()
                {
                    Username = (string)reader["Username"],
                    Password = "TempPassword",
                    //HashedPassword = "TempHashedPassword",
                    Email = (string)reader["Email"],
                    User_Id = (int)reader["U_Id"],
                    Firstname = (string)reader["F_Name"],
                    Lastname = (string)reader["L_Name"],
                    PhoneNumber = (string)reader["Phone_Number"],
                    Birthdate = (DateTime)reader["Birthdate"],
                    Zipcode = (string)reader["Zipcode"]
                };
                return acc;
            }
            return null;
        }
        catch (SqlException e)
        {
            Log.Error("Get Account by id failed: " + e);
            throw e;
        }
    }

    public Users? GetUserByUserID(int u_Id)
    {
        try
        {
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
            connection.Open();

            using SqlCommand command = new("SELECT * FROM Users WHERE Users.User_Id = @UserId", connection);
            command.Parameters.AddWithValue("@UserId", u_Id);

            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Users user = new Users()
                {
                    User_Id = (int)reader["User_Id"],
                    F_Name = (string)reader["F_Name"],
                    L_Name = (string)reader["L_Name"],
                    Phone_Number = (string)reader["Phone_Number"],
                    Zipcode = (string)reader["Zipcode"],
                    Birthdate = (DateTime)reader["Birthdate"]
                };
                return user;
            }
            return null;
        }
        catch (SqlException e)
        {
            Log.Error("Error in getting User by user ID: " + e);
            throw e;
        }

    }

    public Post CreateNewPost(Post post)
    {
        try
        {
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
            connection.Open();

            using SqlCommand command = new("INSERT INTO Posts VALUES (@uId, @likes,@content, @date)", connection);
            command.Parameters.AddWithValue("@uId", post.UserID);
            command.Parameters.AddWithValue("@likes", post.Likes);
            command.Parameters.AddWithValue("@content", post.Content);
            command.Parameters.AddWithValue("@date", post.PostDate);

            command.ExecuteNonQuery();
            return post;
        }
        catch (SqlException e)
        {
            Log.Error("Failed to create new post: " + e);
            throw e;
        }
    }

    public List<Post> GetPostsByUserID(int U_Id)
    {
        try
        {
            List<Post> postList = new List<Post>();
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
            connection.Open();

            using SqlCommand command = new("Select * FROM POSTS WHERE U_Id = @uId Order by Comment_Date DESC", connection);
            command.Parameters.AddWithValue("@uId", U_Id);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                postList.Add(new Post()
                {
                    Content = (string)reader["Content"],
                    PostId = (int)reader["Post_Id"],
                    UserID = (int)reader["U_Id"],
                    Likes = (int)reader["Likes"],
                    PostDate = (DateTime)reader["Comment_Date"]
                });
            }

            return postList;
        }
        catch (SqlException e)
        {
            Log.Error("Unable to get post by ID: " + e);
            throw e;
        }
    }

    public Comment CreateNewComment(Comment com)
    {

        try
        {
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
            connection.Open();
            using SqlCommand command = new("INSERT INTO Comments VALUES (@pId, @likes, @content, @date, @uId)", connection);
            command.Parameters.AddWithValue("@pId", com.PostId);
            command.Parameters.AddWithValue("@likes", com.Likes);
            command.Parameters.AddWithValue("@content", com.Content);
            command.Parameters.AddWithValue("@date", com.CommentDate);
            command.Parameters.AddWithValue("@uId", com.U_id);

            command.ExecuteNonQuery();


            return com;
        }
        catch (SqlException e)
        {
            Log.Error("Unable to create new comment: " + e);
            throw e;
        }

    }

    public List<Comment> GetCommentsByPostID(int P_Id)
    {
        try
        {
            List<Comment> comList = new List<Comment>();
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
            connection.Open();
            string query = "Select Comment_Id, P_Id, Comments.U_Id As U_Id, Comments.Likes AS Likes, Comments.Content AS Content, Comments.Comment_Date AS Date FROM COMMENTS, POSTS WHERE Comments.P_Id =POSTS.Post_Id AND Posts.Post_Id =@pId Order by Comments.Comment_Date DESC";
            using SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@pId", P_Id);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comList.Add(new Comment()
                {
                    CommentId = (int)reader["Comment_Id"],
                    PostId = (int)reader["P_Id"],
                    Likes = (int)reader["Likes"],
                    Content = (string)reader["Content"],
                    CommentDate = (DateTime)reader["Date"],
                    U_id = (int)reader["U_Id"]
                });
            }

            return comList;
        }
        catch (SqlException e)
        {
            Log.Error("Error in getting comments by post ID: " + e);
            throw e;
        }
    }

    public List<Playlist> GetPlaylistsByUserID(int u_Id)
    {
        try
        {
            List<Playlist> pl = new List<Playlist>();
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
            connection.Open();
            using SqlCommand command = new("SELECT Playlist_ID, U_Id, P_Name, Link_Text FROM Playlists JOIN Users ON Playlists.U_id = Users.User_Id WHERE Users.User_Id = @uId", connection);
            command.Parameters.AddWithValue("@uId", u_Id);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                pl.Add(new Playlist()
                {
                    PlaylistId = (int)reader["Playlist_Id"],
                    UserId = (int)reader["U_Id"],
                    Name = (string)reader["P_Name"],
                    SpotifyLink = (string)reader["Link_Text"]
                });
            }

            return pl;
        }
        catch (SqlException e)
        {
            Log.Error("Error getting playlist by ID: " + e);
            throw e;
        }
    }


    public Playlist CreateNewPlaylist(Playlist pl)
    {
        try
        {
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
            connection.Open();
            using SqlCommand command = new("INSERT INTO Playlists VALUES (@uId, @name, @link)", connection);
            command.Parameters.AddWithValue("@uId", pl.UserId);
            command.Parameters.AddWithValue("@name", pl.Name);
            command.Parameters.AddWithValue("@link", pl.SpotifyLink);

            command.ExecuteNonQuery();
            return pl;
        }
        catch (SqlException e)
        {
            Log.Error("Error creating new playlist : " + e);
            throw e;
        }

    }
    public Mood CreateNewMood(Mood mood)
    {
        try
        {
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
            connection.Open();
            using SqlCommand command = new("INSERT INTO Moods VALUES (@uId, @date, @category,@score)", connection);
            command.Parameters.AddWithValue("@uId", mood.UserId);
            command.Parameters.AddWithValue("@category", mood.Category);
            command.Parameters.AddWithValue("@date", mood.Date);
            command.Parameters.AddWithValue("@score", mood.Score);

            command.ExecuteNonQuery();

            return mood;
        }
        catch (SqlException e)
        {
            Log.Error("Error creating a new mood: " + e);
            throw e;
        }
    }

    public List<Mood> GetMoodsByUserID(int u_Id)
    {
        try
        {
            List<Mood> moods = new List<Mood>();
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
            connection.Open();
            using SqlCommand command = new("SELECT * FROM Moods JOIN Users ON Moods.U_Id = Users.User_Id WHERE Users.User_Id = @uId", connection);
            command.Parameters.AddWithValue("@uId", u_Id);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                moods.Add(new Mood()
                {
                    MoodId = (int)reader["Id"],
                    UserId = (int)reader["U_Id"],
                    Date = (DateTime)reader["mDate"],
                    Score = (decimal)reader["Score"],
                    Category = (string)reader["Category"]
                });
            }

            return moods;
        }
        catch (SqlException e)
        {
            Log.Error("Error getting moods by userID: " + e);
            throw e;
        }
    }

    public Friend CreateNewFriend(Friend friend)
    {
        try
        {
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
            connection.Open();
            using SqlCommand command = new("INSERT INTO Friends VALUES (@sId, @tId)", connection);
            command.Parameters.AddWithValue("@tId", friend.TargetId);
            command.Parameters.AddWithValue("@sId", friend.SourceId);

            command.ExecuteNonQuery();

            return friend;
        }
        catch (SqlException e)
        {
            Log.Error("Error creating new friend: " + e);
            throw e;
        }
    }

    public List<Users>? GetFriendsByUserID(int U_Id)
    {
        try
        {
            List<int> friendIds = new List<int>();
            List<Users>? friendsList = new List<Users>();
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
            connection.Open();
            using SqlCommand command = new("SELECT Target_Id FROM Friends WHERE Source_Id = @uId", connection);
            command.Parameters.AddWithValue("@uId", U_Id);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                friendIds.Add((int)reader["Target_Id"]);
            }

            foreach (var id in friendIds)
            {
                friendsList.Add(GetUserByUserID(id));
            }

            return friendsList;
        }
        catch (SqlException e)
        {
            Log.Error("Error getting all friends from userID: " + e);
            throw e;
        }
    }


}