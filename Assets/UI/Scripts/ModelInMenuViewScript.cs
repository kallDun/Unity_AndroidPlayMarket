using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModelInMenuViewScript : MonoBehaviour
{
    public int IdModel;
    public GameObject NameTextObject;
    public GameObject RatingTextObject;
    public GameObject PictureObject;

    private AppModel model;

    void Start()
    {
        try
        {
            model = AppStore.GetById(IdModel);
        }
        catch (Exception e)
        {
            print("Exception occured when trying to read the model. " + e.Message);
        }
        try
        {
            SetNameView();
            SetRatingView();
            SetAppImageView();
        }
        catch (Exception e)
        {
            print("Exception occured when trying to override fields " +
                "according to model data. " + e.Message);
        }
    }

    private void SetAppImageView()
    {
        Sprite image = Resources.Load<Sprite>(model.Image);
        PictureObject.GetComponent<Image>().sprite = image;
    }
    private void SetRatingView()
    {
        RatingTextObject.GetComponent<TextMeshProUGUI>().text = string.Format("{0:0.0}", model.Rating);
    }
    private void SetNameView()
    {
        const int max_length = 38;
        string name = model.Name;
        if (name.Length > max_length)
        {
            name = name.Substring(0, max_length).Trim() + "...";
        }
        NameTextObject.GetComponent<TextMeshProUGUI>().text = name;
    }

    // On click
    public void OnClick()
    {
        AppStore.SelectedModel = model;
        SceneManager.LoadScene("ModelView", LoadSceneMode.Single);
    }
}