using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class PlaylistController : ControllerBase
{
    private readonly PlaylistService _service;

    public PlaylistController(PlaylistService service)
    {
        _service = service;
    }

    [HttpPost("Playlist")]
    public ActionResult<Comment> CreatePlaylist([FromBody] Playlist pl)
    {
        return Created("/Create", _service.CreatePlaylist(pl));
    }
    [HttpGet("Playlist")]
    public ActionResult<Comment> GetPlaylist([FromQuery] int uId)
    {
        return Created("/GetPlaylist", _service.GetPlaylistsByUserID(uId));
    }
}