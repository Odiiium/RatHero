using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour
{
    public static Skin instance;

    public static Skin currentSkin;

    private void Awake()
    {
        SkinChanger.OnLoaded += SkinInitialize;
    }

    private float healthpoints;
    private float luck;

    public float healthPoints { get { return healthpoints; } }
    public float luckPoints { get { return luck; } set { luck = value; } }

    private void SkinInitialize()
    {
        if (instance == null)
        {
            instance = this;
            SkinChanger.instance.ChangeSkin("DoubleStripeRat");
        }
        else { return; }
    }


}
