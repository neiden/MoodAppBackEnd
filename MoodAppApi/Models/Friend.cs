using System;

namespace Models;

public class Friend
{
    public int FriendId { get; set; }
    public int SourceId { get; set; }
    public int TargetId { get; set; }
}