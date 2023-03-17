
namespace Models;

public class Comment
{
    public string? Content { get; set; }
    public int CommentId { get; set; }
    public int PostId { get; set; }
    public int Likes { get; set; }
    public DateTime CommentDate { get; set; }
}