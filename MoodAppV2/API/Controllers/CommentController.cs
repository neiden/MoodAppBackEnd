using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class CommentController : ControllerBase
{
    private readonly CommentService _service;

    public CommentController(CommentService service)
    {
        _service = service;
    }

    [HttpPost("Comment")]
    public ActionResult<Comment> CreateComment([FromBody] Comment com)
    {
        return Created("/Comment", _service.CreateComment(com));
    }
    [HttpGet("Comment")]
    public ActionResult<Comment> GetComments([FromQuery] int pId)
    {
        return Created("/Comment", _service.GetCommentsByPostId(pId));
    }
}