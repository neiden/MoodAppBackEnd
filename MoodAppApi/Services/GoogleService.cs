using Models;
using DataAccess;
using NaturalLanguageApi;

namespace Services;

public class GoogleService
{
    private readonly IRepo _repo;
    public GoogleService(IRepo repo)
    {
        _repo = repo;
    }

    // public int AnalyzeSentiment(string text)
    // {
    //     var client = LanguageServiceClient.Create();
    //     var response = client.AnalyzeSentiment(Document.FromPlainText(text));
    //     var sentiment = response.DocumentSentiment;

    //     return sentiment;
    // }

    public double CreateScoreByUserID(int u_Id)
    {
        string text = "";

        //Get all posts by this user
        List<Post> allPosts = _repo.GetPostsByUserID(u_Id);

        //Parse these posts so datetime.day = today.day
        foreach (Post p in allPosts)
        {
            if (p.PostDate.Day == DateTime.Now.Day)
            {
                text += p.Content + " ";
            }
        }

        //Call google.analyze(text) , return the score.
        double score = GoogleAPI.AnalyzeSentiment(text);
        return score;
    }



}