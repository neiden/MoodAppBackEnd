using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class MoodController : ControllerBase
{
    private readonly MoodService _service;

    public MoodController(MoodService service)
    {
        _service = service;
    }

    [HttpPost("Mood")]
    public ActionResult<Comment> CreateMood([FromBody] Mood mood)
    {
        return Created("/Mood", _service.CreateMood(mood));
    }
    [HttpGet("Mood")]
    public ActionResult<Comment> GetComments([FromQuery] int uId)
    {
        return Created("/Mood", _service.GetMoodsByUserID(uId));
    }
}