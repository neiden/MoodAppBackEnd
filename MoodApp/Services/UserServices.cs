using Models;
using DataAccess;

namespace Services;

public class UserServices
{
    private readonly IRepo _repo;
    public UserServices(IRepo repo)
    {
        _repo = repo;
    }

    public Users? GetUserByUsername(string Username)
    {
        return _repo.GetUserByUsername(Username);
    }

    public Users? GetUserByUserID(int U_Id)
    {
        return _repo.GetUserByUserID(U_Id);
    }

    public bool Login(string Username, string Pwd)
    {
        Users? users = GetUserByUsername(Username);
        if(users == null)
        {
            return false;
        }
        
    }
}