using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly PostService _service;

    public PostController(PostService service)
    {
        _service = service;
    }

    [HttpPost("Post")]
    public ActionResult<Post> CreatePost([FromBody] Post post)
    {
        return Created("/Post", _service.CreatePost(post));
    }
    [HttpGet("Post")]
    public ActionResult<Post> GetPosts([FromQuery] int uId)
    {
        return Created("/Post", _service.GetPostsByUId(uId));
    }
}