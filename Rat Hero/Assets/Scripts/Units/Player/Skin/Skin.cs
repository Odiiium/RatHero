using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour
{
    public static Skin instance;

    private void Awake()
    {
        SkinChanger.OnLoaded += SkinInitialize;
    }

    private void OnDisable()
    {
        SkinChanger.OnLoaded -= SkinInitialize;

    }

    private void SkinInitialize()
    {
        if (instance == null)
        {
            instance = this;
            SkinChanger.instance.ChangeSkin(PlayerPrefs.GetString("choisedRat"));
        }
        else { return; }
    }

}
