using System.Data.SqlClient;
using Models;

namespace DataAccess;

public class DBRepository : IRepo
{


    public Users Authenticate(string[] loginInfo)
    {
        Users user = new Users();
        using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
        connection.Open();

        using SqlCommand cmd = new SqlCommand("SELECT User_Id, F_Name, L_Name, Phone_Number, Zipcode, Birthdate FROM Logins JOIN Users on Logins.U_Id = Users.User_Id WHERE Logins.Username = @username AND Logins.P_hash_salt = @pass", connection);
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
            command.Parameters.AddWithValue("@Birthdate", DateTime.Now);

            command.CommandType = System.Data.CommandType.Text;

            var result = command.ExecuteScalar();
            int user_ID;
            if (result != null)
            {
                user_ID = (int)result;
            }
            else
            {
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
            throw e;
        }
        return success;
    }

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

    public Account GetUserByUserID(int U_Id)
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
                    HashedPassword = "TempHashedPassword",
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

            using SqlCommand command = new("SELECT Post_Id, U_Id, Likes, Content, Comment_Date FROM Posts JOIN Users ON Posts.U_Id = Users.User_Id WHERE Users.User_Id = @uId", connection);
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
            throw e;
        }
    }

    public Comment CreateNewComment(Comment com)
    {

        try
        {
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
            connection.Open();
            using SqlCommand command = new("INSERT INTO Comments VALUES (@pId, @likes, @content, @date)", connection);
            command.Parameters.AddWithValue("@pId", com.PostId);
            command.Parameters.AddWithValue("@likes", com.Likes);
            command.Parameters.AddWithValue("@content", com.Content);
            command.Parameters.AddWithValue("@date", com.CommentDate);

            command.ExecuteNonQuery();


            return com;
        }
        catch (SqlException e)
        {
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
            using SqlCommand command = new("SELECT Comment_Id, P_Id, Comments.Likes AS Likes, Comments.Content AS Content, Comments.Comment_Date AS Date FROM Comments JOIN Posts ON Comments.P_Id = Posts.Post_Id WHERE Posts.Post_Id = @pId", connection);
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
                    CommentDate = (DateTime)reader["Date"]
                });
            }

            return comList;
        }
        catch (SqlException e)
        {
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
            using SqlCommand command = new("SELECT Id, U_Id, Comment_Date, Category, Score FROM Moods JOIN Users ON Moods.U_Id = Users.User_Id WHERE Users.User_Id = @uId", connection);
            command.Parameters.AddWithValue("@uId", u_Id);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                moods.Add(new Mood()
                {
                    MoodId = (int)reader["Id"],
                    UserId = (int)reader["U_Id"],
                    Date = (DateTime)reader["Comment_Date"],
                    Score = (decimal)reader["Score"],
                    Category = (string)reader["Category"]
                });
            }

            return moods;
        }
        catch (SqlException e)
        {
            throw e;
        }
    }

}