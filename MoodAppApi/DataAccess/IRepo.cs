using Models;
using System.Collections.Generic;

namespace DataAccess;

public interface IRepo
{
    Users Authenticate(string[] loginInfo);
    List<Users> GetAllUsers();
    Login? GetUserByUsername(string Username);
    Users? GetUserByUserID(int U_Id);
    Account? GetAccountByUserID(int U_Id);
    bool UpdateUser(Account updated_acc);

    List<Post> GetPostsByUserID(int U_Id);
    public bool CreateNewUser(Account acc);

    public Post CreateNewPost(Post post);

    public List<Comment> GetCommentsByPostID(int P_Id);
    public Comment CreateNewComment(Comment com);

    public List<Playlist> GetPlaylistsByUserID(int u_Id);
    public Playlist CreateNewPlaylist(Playlist pl);
    public Mood CreateNewMood(Mood mood);
    public List<Mood> GetMoodsByUserID(int u_Id);

    public Friend CreateNewFriend(Friend friend);
    public List<Users>? GetFriendsByUserID(int U_Id);

}