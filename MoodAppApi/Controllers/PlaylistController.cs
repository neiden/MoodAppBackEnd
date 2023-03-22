using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class PlaylistController : ControllerBase
{
    //add logger
    private readonly PlaylistService _service;

    public PlaylistController(PlaylistService service)
    {
        _service = service;
    }

    [HttpPost("Playlists")]
    public ActionResult<Playlist> CreatePlaylist([FromBody] Playlist pl)
    {
        return Created("/Create", _service.CreatePlaylist(pl));
    }

    [HttpGet("Playlists")]
    public ActionResult<Playlist> GetPlaylist([FromQuery] int uId)
    {
        return Created("/GetPlaylist", _service.GetPlaylistsByUserID(uId));
    }
}