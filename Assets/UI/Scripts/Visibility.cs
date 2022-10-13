using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    public bool IsVisible = false;

    void Start()
    {
        gameObject.SetActive(IsVisible);
    }
}