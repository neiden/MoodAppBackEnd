using Models;
using DataAccess;

namespace Services;

public class PlaylistService
{
    private readonly IRepo _repo;
    public PlaylistService(IRepo repo)
    {
        _repo = repo;
    }

    public List<Playlist> GetPlaylistsByUserID(int u_Id)
    {
        return _repo.GetPlaylistsByUserID(u_Id);
    }

    public Playlist CreatePlaylist(Playlist pl)
    {
        return _repo.CreateNewPlaylist(pl);
    }
    


}