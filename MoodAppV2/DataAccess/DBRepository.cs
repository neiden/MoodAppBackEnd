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
    public Boolean CreateNewUser(string[] accInfo)
    {
        bool success = false;
        try
        {
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
            connection.Open();

            using SqlCommand command = new SqlCommand("INSERT INTO USERS(F_Name, L_Name, Phone_Number, Zipcode, Birthdate) VALUES(@F_Name, @L_Name, @Phone_Number, @Zipcode, @Birthdate)", connection);
            command.Parameters.AddWithValue("@F_Name", accInfo[0]);
            command.Parameters.AddWithValue("@L_Name", accInfo[1]);
            command.Parameters.AddWithValue("@Phone_Number", accInfo[2]);
            command.Parameters.AddWithValue("@Zipcode", accInfo[3]);
            command.Parameters.AddWithValue("@Birthdate", DateTime.Now);

            int userId = (int)command.ExecuteScalar();

            using SqlCommand cmd = new SqlCommand("INSERT INTO LOGIN VALUES(@username, @pHash, @pwd, @uId, @email)");
            cmd.Parameters.AddWithValue("@username", accInfo[4]);
            cmd.Parameters.AddWithValue("@uId", userId);
            cmd.Parameters.AddWithValue("@pHash", "password");
            cmd.Parameters.AddWithValue("@pwd", accInfo[5]);
            cmd.Parameters.AddWithValue("@email", accInfo[6]);


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

    public Login? GetUserByUserID(int U_Id)
    {
        using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
        connection.Open();

        using SqlCommand command = new("SELECT * FROM LOGIN WHERE U_Id = @U_Id", connection);
        command.Parameters.AddWithValue("@UserId", U_Id);

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
}