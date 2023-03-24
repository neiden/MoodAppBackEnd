using Models;
using DataAccess;

namespace Services;

public class CommentService
{
    private readonly IRepo _repo;
    public CommentService(IRepo repo)
    {
        _repo = repo;
    }

    public List<Comment> GetCommentsByPostId(int P_Id)
    {
        return _repo.GetCommentsByPostID(P_Id);
    }

    public Comment CreateComment(Comment com)
    {
        return _repo.CreateNewComment(com);
    }
}