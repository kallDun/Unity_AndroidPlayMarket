using System.Collections.Generic;
using System.Linq;

public static class AppStore
{
    public static AppModel SelectedModel { get; set; }

    public static AppModel GetById(int id) => apps.FirstOrDefault(x => x.Id == id);

    static readonly List<AppModel> apps = new()
    {
        new AppModel(id: 0, name: "Komoot — Cycling, Hiking & Mountain in your pocket")
        {
            Description = "From the deepest dirt track to the highest hiking trail, komoot gets you " +
            "there and back again—and everywhere you want in between.",
            Publisher = "komoot GmbH",
            Image = "apps/komoot_pic",
            Screenshots = new[]
            {
                "screens/komoot_1",
                "screens/komoot_2",
                "screens/komoot_3",
                "screens/komoot_4"
            },
            Rating = 4.5f,
            Ratings = new()
            {
                { 5, 23600 },
                { 4, 3000 },
                { 3, 450 },
                { 2, 52 },
                { 1, 127 }
            },
            FileSize = "45 MB",
            ContainsAds = true,
            ContainsInAppPurchases = true,
            Comments = new[]
            {
                new CommentModel(id: 0)
                {
                    Comment = "App is excelent except user interface.",
                    Rating = 4,
                    Date = new(year: 2020, month: 10, day: 18),
                    ProfileName = "Grigory",
                    ProfilePic = "profiles/p2"
                },
                new CommentModel(id: 1)
                {
                    Comment = "Nobody knows how I low this app!!!!",
                    Rating = 5,
                    Date = new(year: 2019, month: 09, day: 15),
                    ProfileName = "Max",
                    ProfilePic = "profiles/p4"
                }
            }
        },
        new AppModel(id: 1, name: "WhatsApp Messenger")
        {
            Description = "WhatsApp from Meta is a FREE messaging and video calling app. It’s used by over 2B people in more than 180 countries. " +
            "It’s simple, reliable, and private, so you can easily keep in touch with your friends and family. " +
            "WhatsApp works across mobile and desktop even on slow connections, with no subscription fees*.",
            Publisher = "WhatsApp LLC",
            Image = "apps/whatsapp",
            Screenshots = new[]
            {
                "screens/whatsapp_1",
                "screens/whatsapp_2",
                "screens/whatsapp_3",
                "screens/whatsapp_4"
            },
            Rating = 4.3f,
            Ratings = new()
            {
                { 5, 60030060 },
                { 4, 50040200 },
                { 3, 46010000 },
                { 2, 10000000 },
                { 1, 21004530 }
            },
            FileSize = "69 MB",
            ContainsAds = true,
            ContainsInAppPurchases = true,
            Comments = new[]
            {
                new CommentModel(id: 0)
                {
                    Comment = "App is terrifying.",
                    Rating = 1,
                    Date = new(year: 2022, month: 09, day: 25),
                    ProfileName = "Ted",
                    ProfilePic = "profiles/p1"
                },
                new CommentModel(id: 1)
                {
                    Comment = "Thanks God, now I can see my grandsons!",
                    Rating = 5,
                    Date = new(year: 2022, month: 09, day: 24),
                    ProfileName = "Your granny",
                    ProfilePic = "profiles/p3"
                }
            }
        },
        new AppModel(id: 2, name: "Firefox Fast & Private Browser")
        {
            Description = "We know there are a lot of choices out there, some of them produced by huge tech companies, " +
            "but in choosing Firefox you’re joining a unique community that’s actively helping to diversify the " +
            "way people experience the internet.",
            Publisher = "Mozilla",
            Image = "apps/firefox",
            Screenshots = new[]
            {
                "screens/firefox_1",
                "screens/firefox_2",
                "screens/firefox_3",
                "screens/firefox_4"
            },
            Rating = 4.5f,
            Ratings = new()
            {
                { 5, 64530060 },
                { 4, 5004020 },
                { 3, 4631000 },
                { 2, 1005600 },
                { 1, 10100453 }
            },
            FileSize = "130 MB",
            ContainsAds = true,
            Comments = new[]
            {
                new CommentModel(id: 0)
                {
                    Comment = "The best browser in the world!",
                    Rating = 5,
                    Date = new(year: 2022, month: 09, day: 25),
                    ProfileName = "Johny",
                    ProfilePic = "profiles/p5"
                },
                new CommentModel(id: 1)
                {
                    Comment = "This is ok. Do something with energy saving.",
                    Rating = 3,
                    Date = new(year: 2022, month: 09, day: 24),
                    ProfileName = "Max",
                    ProfilePic = "profiles/p1"
                }
            }
        }
    };
}