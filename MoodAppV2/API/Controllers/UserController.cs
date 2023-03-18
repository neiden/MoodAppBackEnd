using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers;

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
    public ActionResult<Users> Register([FromBody] Account acc)
    {
        return Created("/Register", _service.RegisterUser(acc));

    }

    [HttpGet("GetAccount")]

    public ActionResult<Users> GetAccount([FromQuery] int User_Id)
    {
        return Created("/Users", _service.GetAccountByUserID(User_Id));
    }


    [HttpGet("Login")]

    public ActionResult<Users> Login([FromQuery] string[] info)
    {
        return Created("/Login", _service.Authenticate(info));
    }

}



