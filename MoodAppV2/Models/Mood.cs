namespace Models;

public class Mood
{
    public int MoodId { get; set; }
    public int UserId { get; set; }
    public DateTime Date { get; set; }
    public string? Category { get; set; }
    public decimal Score { get; set; }
}