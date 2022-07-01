using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffUIView : MonoBehaviour
{
    internal static GameObject[] buffImages = new GameObject[4];

    internal void InitializeUIElements()
    {
        for (int i = 0; i < 4; i++)
        {
            buffImages[i] = transform.GetChild(i).gameObject;
        }
        HideImages();
    }

    internal void HideImages()
    {
        for (int i = 0; i < buffImages.Length; i++)
        {
            buffImages[i].gameObject.SetActive(false);
        }
    }
}
