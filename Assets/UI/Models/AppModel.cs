using System.Collections.Generic;

public class AppModel
{
    public AppModel(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Publisher { get; set; }
    public string Image { get; set; }
    public bool ContainsAds { get; set; } = false;
    public bool ContainsInAppPurchases { get; set; } = false;
    public string AgeRestriction { get; set; } = "Everyone";
    public string[] Screenshots { get; set; }
    public float Rating { get; set; }
    public Dictionary<int, int> Ratings { get; set; }
    public string FileSize { get; set; }
    public CommentModel[] Comments { get; set; }
}