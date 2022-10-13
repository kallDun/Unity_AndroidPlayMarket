using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommentScript : MonoBehaviour
{
    public GameObject ProfilePic;
    public GameObject ProfileName;
    public GameObject Rating;
    public GameObject Date;
    public GameObject Text;

    private void Start()
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    public void ChangeView(CommentModel comment)
    {
        Date.GetComponent<TextMeshProUGUI>().text = comment.Date.ToString("dd.MM.yyyy");
        Text.GetComponent<TextMeshProUGUI>().text = comment.Comment;
        ProfileName.GetComponent<TextMeshProUGUI>().text = comment.ProfileName;
        ProfilePic.GetComponent<Image>().sprite = Resources.Load<Sprite>(comment.ProfilePic);
        var rt = Rating.GetComponent<RatingStarsScript>();
        rt.Rating = comment.Rating;
        rt.SetRating();
    }
}