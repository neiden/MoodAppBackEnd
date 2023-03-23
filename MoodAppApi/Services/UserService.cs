using Models;
using DataAccess;

namespace Services;

public class UserService
{
    private readonly IRepo _repo;
    private readonly PasswordService _pservice = new PasswordService();
    public UserService(IRepo repo)
    {
        _repo = repo;
    }

    public Users Authenticate(string[] loginInfo)
    {
        // Hash the password here 
        // loginInfo[1] = _pservice.HashPassword(loginInfo[1]);
        // Console.WriteLine("Hashed password: " + loginInfo[1]);
        return _repo.Authenticate(loginInfo);
    }

    public bool RegisterUser(Account acc)
    {
        if(acc.Username == ""){
            acc.Username = "Testuser";
        }
        acc.PhoneNumber = "12345644";
        return _repo.CreateNewUser(acc);
    }

    public Login? GetUserByUsername(string Username)
    {
        return _repo.GetUserByUsername(Username);
    }

    public Account GetAccountByUserID(int U_Id)
    {
        return _repo.GetAccountByUserID(U_Id);
    }

    public Users GetUserByUserID(int U_Id){
        return _repo.GetUserByUserID(U_Id);
    }

    public List<Users> GetAllUsers(){
        return _repo.GetAllUsers();
    }

    public Account UpdateAccount(Account updatedAccount){
        Account? newAcc = new();
        int id = updatedAccount.User_Id;
        if(_repo.UpdateUser(updatedAccount)){
            return _repo.GetAccountByUserID(id);
            
        }

        return newAcc;
    }


}