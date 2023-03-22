using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class MoodController : ControllerBase
{
    //add logger
    private readonly MoodService _service;

    public MoodController(MoodService service)
    {
        _service = service;
    }

    [HttpPost("Moods")]
    public ActionResult<Comment> CreateMood([FromBody] Mood mood)
    {
        return Created("/Moods", _service.CreateMood(mood));
    }

    [HttpGet("Moods")]
    public ActionResult<Comment> GetComments([FromQuery] int uId)
    {
        return Created("/Moods", _service.GetMoodsByUserID(uId));
    }
}