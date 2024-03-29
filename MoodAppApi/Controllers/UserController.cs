using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    //add logger
    private readonly UserService _service;
    public UserController(UserService service)
    {
        _service = service;
    }

    [HttpPost("Users")]
    public ActionResult<Users> Register([FromQuery] string[] info)
    {
        Account acc = new();
        acc.Firstname = info[0];
        acc.Lastname = info[1];
        acc.Username = info[2];
        acc.Email = info[3];
        acc.Password = info[4];
        //acc.Birthdate = new DateTime(1969,10,31);
        acc.Birthdate = DateTime.Parse(info[5]);
        Console.WriteLine(acc.Birthdate);
        acc.Zipcode = info[6];
        acc.PhoneNumber = info[7];
        return Created("/users", _service.RegisterUser(acc));

    }

    [HttpGet("Users")]

    public ActionResult<Users> GetAccount([FromQuery] int User_Id)
    {
        return Created("/users", _service.GetAccountByUserID(User_Id));
    }


    [HttpGet("Login")]

    public ActionResult<Users> Login([FromQuery] string[] info)
    {
        return Created("/Login", _service.Authenticate(info));
    }

    [HttpGet("AllUsers")]
    public ActionResult<Users> GetUsers(){
        return Created("/userlist", _service.GetAllUsers());
    }

    [HttpPut("Users")]
    public ActionResult<Account> UpdateAccount([FromQuery] string[] up){
         Account acc = new();
        acc.Firstname = up[0];
        acc.Lastname = up[1];
        acc.Username = up[2];
        acc.Email = up[3];
        acc.Password = up[4];
        //acc.Birthdate = new DateTime(1969,10,31);
        acc.Birthdate = DateTime.Parse(up[5]);
        acc.Zipcode = up[6];
        acc.PhoneNumber = up[7];
        acc.User_Id = Int32.Parse(up[8]);
        if(acc == null){
            Console.WriteLine("empty");//loggin moment
        }
        return Created("/user", _service.UpdateAccount(acc));
    }

}



