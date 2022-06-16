using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class RatSwitcher : MonoBehaviour
{
    [SerializeField] internal string[] rats;

    static public int currentRat;

    internal void SwitchToLeft()
    {
        SkinChanger skinChanger = FindObjectOfType<SkinChanger>();
        if (currentRat != 0)
        {
            skinChanger.ChangeSkin(rats[currentRat - 1]);
            currentRat--;
            DisplayRat();
        }
        else
        {
            skinChanger.ChangeSkin(rats[rats.Length - 1]);
            currentRat = rats.Length - 1;
            DisplayRat();
        }
    }

    internal void SwitchToRight()
    {
        SkinChanger skinChanger = FindObjectOfType<SkinChanger>();
        if (currentRat != rats.Length - 1)
        {
            skinChanger.ChangeSkin(rats[currentRat + 1]);
            currentRat++;
            DisplayRat();
        }
        else
        {
            skinChanger.ChangeSkin(rats[0]);
            currentRat = 0;
            DisplayRat();
        }
    }

    internal void SelectRat()
    {
        if (PlayerPrefs.GetInt(rats[currentRat]) == 1)
        {
            PlayerPrefs.SetString("choisedRat", rats[currentRat]);
        }
        else { PlayerPrefs.SetString("choisedRat", "DoubleStripeRat"); }
    }

    private void DisplayRat()
    {
        DisplayRatStats();
        if (PlayerPrefs.GetInt(rats[currentRat]) == 1) RatShopController.onHide?.Invoke();
        else RatShopController.onShow?.Invoke();
    }

    private void DisplayRatStats()
    {
        RatAdditionalStatsController.onStatsDisplay?.Invoke();
    }

}
