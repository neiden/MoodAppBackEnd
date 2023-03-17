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

    public List<Mood> GetMoodsByUserID(int u_Id)
    {
        return _repo.GetMoodsByUserID(u_Id);
    }

    public Mood CreateMood(Mood mood)
    {
        return _repo.CreateNewMood(mood);
    }



}