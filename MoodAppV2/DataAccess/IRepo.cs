using Models;
using System.Collections.Generic;

namespace DataAccess;

public interface IRepo
{
    Users Authenticate(string[] loginInfo);
    List<Users> GetAllUsers();
    Login? GetUserByUsername(string Username);
    Login? GetUserByUserID(int U_Id);
    public bool CreateNewUser(string[] accInfo);

}