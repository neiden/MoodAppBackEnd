using Models;
using System.Collections.Generic;

namespace DataAccess;

public interface IRepo
{
    Users Authenticate(string[] loginInfo);
    List<Users> GetAllUsers();
    Login? GetUserByUsername(string Username);
    Account GetUserByUserID(int U_Id);

    List<Post> GetPostsByUserID(int U_Id);
    public bool CreateNewUser(Account acc);

    public Post CreateNewPost(Post post);

    public List<Comment> GetCommentsByPostID(int P_Id);
    public Comment CreateNewComment(Comment com);

    public List<Playlist> GetPlaylistsByUserID(int u_Id);
    public Playlist CreateNewPlaylist(Playlist pl);
    public Mood CreateNewMood(Mood mood);
    public List<Mood> GetMoodsByUserID(int u_Id);

}