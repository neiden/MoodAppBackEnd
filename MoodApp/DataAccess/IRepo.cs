using Models;
using System.Collections.Generic;

namespace DataAcess;

public interface IRepo
{
    List<Users> GetAllUsers();
    Login? GetUserByUsername(string Username);
    Login? GetUserByUserID(int U_Id);
    public bool CreateNewUser(Users newUser);
    
}