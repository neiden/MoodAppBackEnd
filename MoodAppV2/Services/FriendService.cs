using Models;
using DataAccess;

namespace Services;

public class FriendService
{
    private readonly IRepo _repo;
    public FriendService(IRepo repo)
    {
        _repo = repo;
    }

    public List<Users> GetFriendsByUserID(int U_Id)
    {
        return _repo.GetFriendsByUserID(U_Id);
    }

    public Friend CreateNewFriend(Friend friend)
    {
        return _repo.CreateNewFriend(friend);
    }



}