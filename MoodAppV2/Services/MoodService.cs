using Models;
using DataAccess;

namespace Services;

public class MoodService
{
    private readonly IRepo _repo;
    public MoodService(IRepo repo)
    {
        _repo = repo;
    }

    public List<Mood> GetCommentsByPostId(int P_Id)
    {
        //return _repo.GetCommentsByPostID(P_Id);
        return null;
    }

    public Comment CreateComment(Comment com)
    {
        return _repo.CreateNewComment(com);
    }



}