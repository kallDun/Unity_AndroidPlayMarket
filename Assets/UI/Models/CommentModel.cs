using System;

public class CommentModel
{
    public CommentModel(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
    public int Rating { get; set; }
    public DateTime Date { get; set; }
    public string Comment { get; set; }
    public string ProfileName { get; set; }
    public string ProfilePic { get; set; }
}