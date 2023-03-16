using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace MoodApi.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly Service _service;
    public UserController(ILogger<UserController> logger, Service service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost("Register")]
    public ActionResult<Users> Register([FromBody]Users users)
    {
        if(string.IsNullOrWhiteSpace(user.Username) == false &&
           string.IsNullOrWhiteSpace(user.Pwd) == false)
           {
            // Check to see if the User's provided username gets anything from db and match them together
            // if no match then create user then bad request
            if(users.Username != _service.GetUserByUsername(users.Username).Username)
            {
                // make sure any entry in coinbank and click power is changed to default new user settings 
    
                PasswordHasher ph = new PasswordHasher();
                user.Password = ph.PasswordHash(user.Pwd);
                return Created("/Register", _service.createUserinDB(user));
            }
            else{
                return BadRequest("Username is already taken");
            }
        }
        else{
            return BadRequest("Entry must not contain any null values");
        }
    }

      [HttpPost("Login")]
    public ActionResult<Users> Login([FromBody]Users users)
    {
        if(string.IsNullOrWhiteSpace(user.Username) == false &&
           string.IsNullOrWhiteSpace(user.Pwd) == false)
           {
            // Check to see if the User's provided username gets anything from db and match them together
            // if no match then create user then bad request
            if(users.Username != _service.GetUserByUserID(users.Username).Username)
            {
                // make sure any entry in coinbank and click power is changed to default new user settings 
    
                PasswordHasher ph = new PasswordHasher();
                user.Password = ph.PasswordHash(user.Pwd);
                return Created("/Login", _service.createUserinDB(user));
            }
            else{
                return BadRequest("Id is already taken");
            }
        }
        else{
            return BadRequest("Entry must not contain any null values");
        }
    }

}



