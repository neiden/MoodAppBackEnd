using System;

namespace Models;

public class Playlist
{
    public int PlaylistId { get; set; }
    public int UserId { get; set; }
    public string? Name { get; set; }
    public string? SpotifyLink { get; set; }


}