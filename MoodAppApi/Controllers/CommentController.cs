using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using Serilog;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class CommentController : ControllerBase
{
    //add logger
    private readonly CommentService _service;

    public CommentController(CommentService service)
    {
        _service = service;
    }

    [HttpPost("Comments")]
    public ActionResult<Comment> CreateComment([FromBody] Comment com)
    {
        return Created("/Comments", _service.CreateComment(com));
    }
    [HttpGet("Comments")]
    public ActionResult<Comment> GetComments([FromQuery] int pId)
    {
        return Created("/Comments", _service.GetCommentsByPostId(pId));
    }
}