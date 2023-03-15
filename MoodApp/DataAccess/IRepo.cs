using Models;
using System.Collections.Generic;

public interface IRepo{
    List<Users> GetAllUsers();
    Users? GetUserByUsername(string Username);  
    Users? GetUserByUserID(int U_Id);
    void CreateNewUser(Users newUser);
}