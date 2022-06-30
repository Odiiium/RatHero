using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffUIView : MonoBehaviour
{
    internal static Image[] buffImages = new Image[4];

    internal void InitializeUIElements()
    {
        for (int i = 0; i< 4; i++)
        {
            buffImages[i] = transform.GetChild(i).GetChild(0).GetComponent<Image>();
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
