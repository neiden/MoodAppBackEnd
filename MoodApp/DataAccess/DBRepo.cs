using System;
using System.Text.Json;
using System.Data.SqlClient;
using Models;

namespace DataAccess;

public class DBRepo : IRepo
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

        while(reader.Read())
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

    /// <summary>
    /// Data persistence for creating a new user
    /// </summary>
    public void CreateNewUser(Users newUser)
    {
        using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
        connection.Open();

        using SqlCommand command = new SqlCommand("INSERT IMTO USERS(User_Id, F_Name, L_Name, Phone_Number, Zipcode, Birthdate) VALUES(@User_Id, @F_Name, @L_Name, @Phone_Number, @Zipcode, @Birthdate)", connection);
        command.Parameters.AddWithValue(@"User_Id",newUser.User_Id);
        command.Parameters.AddWithValue("@F_Name",newUser.F_Name);
        command.Parameters.AddWithValue("@L_Name",newUser.L_Name);
        command.Parameters.AddWithValue("@Phone_Number",newUser.Phone_Number);
        command.Parameters.AddWithValue("@Zipcode",newUser.Zipcode);
        command.Parameters.AddWithValue("@Birthdate",newUser.Birthdate);

        command.ExecuteNonQuery();
    }

    public Users? GetUserByUsername(string Username)
    {
        using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
        connection.Open();

        using SqlCommand command = new SqlCommand();
        command.Parameters.AddWithValue();

        command.ExecuteNonQuery();
    }

    public Users? GetUserByUserID(int U_Id)
    {
        using SqlConnection connection = new SqlConnection(Secrets.getConnectionString());
        connection.Open();

        using SqlCommand command = new SqlCommand();
        command.Parameters.AddWithValue();
        using SqlDataReader reader = command.ExecuteReader();

        while(reader.Read())
        {
            Users? users = new Users(

            );
            return users;
        }
        return null;
        

    }
}