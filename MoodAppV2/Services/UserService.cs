using Models;
using DataAccess;

namespace Services;

public class UserService
{
    private readonly IRepo _repo;
    public UserService(IRepo repo)
    {
        _repo = repo;
    }

    // public Users? CreateNewUser(Users users)
    // {
    //     // return _repo.CreateNewUser(users);
    // }

    public Login? GetUserByUsername(string Username)
    {
        return _repo.GetUserByUsername(Username);
    }

    public Login? GetUserByUserID(int U_Id)
    {
        return _repo.GetUserByUserID(U_Id);
    }


}