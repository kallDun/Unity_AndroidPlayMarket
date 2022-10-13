using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ViewModelScript : MonoBehaviour
{
    AppModel model;

    // public
    public GameObject PictureObject;
    public GameObject[] ScreenshotObjects;
    public GameObject NameObject;
    public GameObject DescriptionObject;
    public GameObject PublisherObejct;
    public GameObject AdditionalInfoObejct;
    public GameObject[] RatingObjects;
    public GameObject RatingObjectInStars;
    public GameObject ReviewsObject;
    public GameObject ReviewsDetailedObject;
    public GameObject FileSizeObject;
    public GameObject AgeRestrictObject;
    public GameObject FiveStarRatings, FourStarRatings, ThreeStarRatings, TwoStarRatings, OneStarRatings;
    public GameObject CommentsList;


    void Start()
    {
        // check for selected application
        model = AppStore.SelectedModel;
        if (model is null)
        {
            ReturnBack();
            return;
        }

        SetViewsForAppImageAndAppScreenshots();
        SetViewsForMainTextComponents();
        SetViewsForRatingComponents();

        int reviews_count = model.Ratings.Values.Sum();
        SetShortlyReviewsCount(reviews_count);
        SetDetailedReviewsCount(reviews_count);
        SetReviewsCountByStars(reviews_count);
        
        SpawnComments();
    }

    private void SpawnComments()
    {
        foreach (var item in model.Comments)
        {
            GameObject comment = Instantiate(Resources.Load("Comment")) as GameObject;
            comment.transform.SetParent(CommentsList.transform);
            comment.GetComponent<CommentScript>().ChangeView(item);
        }
    }
    private void SetReviewsCountByStars(int reviews_count)
    {
        FiveStarRatings.GetComponent<Slider>().value =
                    model.Ratings.Where(x => x.Key == 5).First().Value * 1.0f / reviews_count;
        FourStarRatings.GetComponent<Slider>().value =
            model.Ratings.Where(x => x.Key == 4).First().Value * 1.0f / reviews_count;
        ThreeStarRatings.GetComponent<Slider>().value =
            model.Ratings.Where(x => x.Key == 3).First().Value * 1.0f / reviews_count;
        TwoStarRatings.GetComponent<Slider>().value =
            model.Ratings.Where(x => x.Key == 2).First().Value * 1.0f / reviews_count;
        OneStarRatings.GetComponent<Slider>().value =
            model.Ratings.Where(x => x.Key == 1).First().Value * 1.0f / reviews_count;
    }
    private void SetDetailedReviewsCount(int reviews_count)
    {
        string temp = reviews_count.ToString();
        string detailed_reviews = "";
        for (int i = 0, j = temp.Length - 1; j >= 0; i++, j--)
        {
            if (i % 3 == 0 && i != 0) detailed_reviews = " " + detailed_reviews;
            detailed_reviews = temp[j] + detailed_reviews;
        }
        ReviewsDetailedObject.GetComponent<TextMeshProUGUI>().text = detailed_reviews;
    }
    private void SetShortlyReviewsCount(int reviews_count)
    {
        string reviews =
                    reviews_count > 1000000
                    ? $"{reviews_count / 1000000}M"
                    : reviews_count > 1000
                    ? $"{reviews_count / 1000}K"
                    : $"{reviews_count}";
        reviews += " reviews";
        ReviewsObject.GetComponent<TextMeshProUGUI>().text = reviews;
    }
    private void SetViewsForRatingComponents()
    {
        foreach (var item in RatingObjects)
        {
            item.GetComponent<TextMeshProUGUI>().text = string.Format("{0:0.0}", model.Rating);
        }
        var rt = RatingObjectInStars.GetComponent<RatingStarsScript>();
        rt.Rating = model.Rating;
        rt.SetRating();
    }
    private void SetViewsForMainTextComponents()
    {
        NameObject.GetComponent<TextMeshProUGUI>().text = model.Name;
        DescriptionObject.GetComponent<TextMeshProUGUI>().text = model.Description;
        PublisherObejct.GetComponent<TextMeshProUGUI>().text = model.Publisher;
        FileSizeObject.GetComponent<TextMeshProUGUI>().text = model.FileSize;
        AgeRestrictObject.GetComponent<TextMeshProUGUI>().text = model.AgeRestriction;
        AdditionalInfoObejct.GetComponent<TextMeshProUGUI>().text =
            model.ContainsAds || model.ContainsInAppPurchases
            ? model.ContainsAds && !model.ContainsInAppPurchases
            ? "Contains ads"
            : !model.ContainsAds && model.ContainsInAppPurchases
            ? "In-app purchases"
            : "Contains ads · In-app purchases"
            : "";
    }
    private void SetViewsForAppImageAndAppScreenshots()
    {
        PictureObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(model.Image);
        for (int i = 0; i < ScreenshotObjects.Length && i < model.Screenshots.Length; i++)
        {
            ScreenshotObjects[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(model.Screenshots[i]);
        }
    }


    // On Click
    public void ReturnBack()
    {
        AppStore.SelectedModel = null;
        SceneManager.LoadScene("MainMenuView", LoadSceneMode.Single);
    }
}