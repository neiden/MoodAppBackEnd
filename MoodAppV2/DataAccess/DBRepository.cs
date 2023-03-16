using System.Data.SqlClient;
using Models;

namespace DataAccess;

public class DBRepository : IRepo
{
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
            (DateOnly)reader["Birthdate"]
            ));
        }
        return allUsers;
    }

    ///<summary>
    ///Data persistence for creating a new user
    ///</summary>
    public Boolean CreateNewUser(Users newUser)
    {
        try
        {
            using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
            connection.Open();

            using SqlCommand command = new SqlCommand("INSERT INTO USERS(User_Id, F_Name, L_Name, Phone_Number, Zipcode, Birthdate) VALUES(@User_Id, @F_Name, @L_Name, @Phone_Number, @Zipcode, @Birthdate)", connection);
            command.Parameters.AddWithValue(@"User_Id", newUser.User_Id);
            command.Parameters.AddWithValue("@F_Name", newUser.F_Name);
            command.Parameters.AddWithValue("@L_Name", newUser.L_Name);
            command.Parameters.AddWithValue("@Phone_Number", newUser.Phone_Number);
            command.Parameters.AddWithValue("@Zipcode", newUser.Zipcode);
            command.Parameters.AddWithValue("@Birthdate", newUser.Birthdate);

            using SqlCommand cmd = new SqlCommand("INSERT INTO LOGIN VALUES(@username, @pHash, @pwd, @uId, @email)");
            command.Parameters.AddWithValue(@"username", newUser.Username);
            command.Parameters.AddWithValue("@F_Name", newUser.F_Name);
            command.Parameters.AddWithValue("@L_Name", newUser.L_Name);
            command.Parameters.AddWithValue("@Phone_Number", newUser.Phone_Number);
            command.Parameters.AddWithValue("@Zipcode", newUser.Zipcode);


            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }
        catch (SqlException e)
        {
            throw e;
        }
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