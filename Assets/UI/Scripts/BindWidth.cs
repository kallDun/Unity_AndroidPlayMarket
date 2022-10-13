using UnityEngine;

public class BindWidth : MonoBehaviour
{
    private int width;
    void Start() => Bind();

    private void Update()
    {
        if (Screen.width != width) Bind();
    }
    private void Bind()
    {
        RectTransform transform = gameObject.GetComponent<RectTransform>();
        transform.sizeDelta = new Vector2(Screen.width, 0f);
        width = Screen.width;
    }
}