using Models;
using DataAccess;

namespace Services;

public class PostService
{
    private readonly IRepo _repo;
    public PostService(IRepo repo)
    {
        _repo = repo;
    }

    public List<Post> GetPostsByUId(int U_Id)
    {
        return _repo.GetPostsByUserID(U_Id);
    }

    public Post CreatePost(Post post)
    {
        return _repo.CreateNewPost(post);
    }



}