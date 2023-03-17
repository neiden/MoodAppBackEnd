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

    public bool? CreateNewUser(Users users)
    {
        return _repo.CreateNewUser(users);
    }

    public Login? GetUserByUsername(string Username)
    {
        return _repo.GetUserByUsername(Username);
    }

    public Login? GetUserByUserID(int U_Id)
    {
        return _repo.GetUserByUserID(U_Id);
    }
}