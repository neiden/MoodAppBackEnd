namespace Models;

public class Post
{
    public string? Content { get; set; }
    public int PostId { get; set; }
    public int Likes { get; set; }
    public DateTime PostDate { get; set; }
    public int UserID { get; set; }
}