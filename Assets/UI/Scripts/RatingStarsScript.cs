using UnityEngine;
using UnityEngine.UI;

public class RatingStarsScript : MonoBehaviour
{
    public float Rating;
    public GameObject ProgressBarObject;

    private void Start() => SetRating();
    public void SetRating()
    {
        ProgressBarObject.GetComponent<Slider>().value = Rating / 5.0f;
    }
}