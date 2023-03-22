using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    //add logger
    private readonly PostService _service;

    public PostController(PostService service)
    {
        _service = service;
    }

    [HttpPost("Posts")]
    public ActionResult<Post> CreatePost([FromBody] Post post)
    {
        return Created("/Posts", _service.CreatePost(post));
    }

    [HttpGet("Posts")]
    public ActionResult<Post> GetPosts([FromQuery] int uId)
    {
        return Created("/Posts", _service.GetPostsByUId(uId));
    }
}