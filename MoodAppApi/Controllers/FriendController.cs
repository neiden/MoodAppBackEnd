using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class FriendController : ControllerBase
{
    //add logger
    private readonly FriendService _service;

    public FriendController(FriendService service)
    {
        _service = service;
    }

    [HttpPost("Friends")]
    public ActionResult<Friend> CreateFriend([FromBody] Friend friend)
    {
        return Created("/Friends", _service.CreateNewFriend(friend));
    }

    [HttpGet("Friends")]
    public ActionResult<Friend> GetFriends([FromQuery] int uId)
    {
        return Created("/Friends", _service.GetFriendsByUserID(uId));
    }
}