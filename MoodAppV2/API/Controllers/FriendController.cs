using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class FriendController : ControllerBase
{
    private readonly FriendService _service;

    public FriendController(FriendService service)
    {
        _service = service;
    }

    [HttpPost("Friend")]
    public ActionResult<Friend> CreateFriend([FromBody] Friend friend)
    {
        return Created("/Friend", _service.CreateNewFriend(friend));
    }
    [HttpGet("Friend")]
    public ActionResult<Friend> GetFriends([FromQuery] int uId)
    {
        return Created("/Friend", _service.GetFriendsByUserID(uId));
    }
}