using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class GoogleController : ControllerBase
{
    private readonly GoogleService _service;

    public GoogleController(GoogleService service)
    {
        _service = service;
    }

    [HttpGet("Google")]
    public ActionResult<double> CreateScore([FromQuery] int u_Id)
    {
        return Created("/Google", _service.CreateScoreByUserID(u_Id));
    }

}