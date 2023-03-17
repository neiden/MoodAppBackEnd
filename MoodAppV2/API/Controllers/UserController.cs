using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace MoodApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _service;
    public UserController(UserService service)
    {
        _service = service;
    }

    [HttpPost("Register")]
    public ActionResult<Users> Register([FromBody] string[] accInfo)
    {
        return Created("/Register", _service.RegisterUser(accInfo));

        // if (string.IsNullOrWhiteSpace(users.Username) == false &&
        //    string.IsNullOrWhiteSpace(users.Pwd) == false)
        // {
        //     // Check to see if the User's provided username gets anything from db and match them together
        //     // if no match then create user then bad request
        //     if (users.Username != _service.GetUserByUsername(users.Username).Username)
        //     {
        //         // make sure any entry in coinbank and click power is changed to default new user settings 

        //         PasswordHasher ph = new PasswordHasher();
        //         users.Password = ph.PasswordHash(users.Pwd);
        //         //password = ph.PasswordHash(users.Pwd);
        //         return Created("/Register", _service.createUser(users));
        //     }
        //     else
        //     {
        //         return BadRequest("Username is already taken");
        //     }
        // }
        // else
        // {
        //     return BadRequest("Entry must not contain any null values");
        // }
    }


    [HttpGet("Login")]

    public ActionResult<Users> Login([FromQuery] string[] info)
    {
        return Created("/Login", _service.Authenticate(info));
        // if (string.IsNullOrWhiteSpace(urse.Username) == false &&
        //    string.IsNullOrWhiteSpace(user.Pwd) == false)
        // {
        //     // Check to see if the User's provided username gets anything from db and match them together
        //     // if no match then create user then bad request
        //     if (users.Username != _service.GetUserByUserID(users.Username).Username)
        //     {
        //         // make sure any entry in coinbank and click power is changed to default new user settings 

        //         PasswordHasher ph = new PasswordHasher();
        //         user.Password = ph.PasswordHash(user.Pwd);
        //         return Created("/Login", _service.createUserinDB(user));
        //     }
        //     else
        //     {
        //         return BadRequest("Id is already taken");
        //     }
        // }
        // else
        // {
        //     return BadRequest("Entry must not contain any null values");
        // }
    }

}



