using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatShop : MonoBehaviour
{
    public static Dictionary<string, int> ratsPrice = new Dictionary<string, int>() // Dictionary which contains price 
    {
        {"AlbinoRat", 100 },
        {"RedHatRat", 200 },
        {"ArthasRat", 400 }
    };

    public static Dictionary<string, string> moneyType = new Dictionary<string, string>() // Dictionary which contains currency ( cheese or diamonds )
    {
        {"AlbinoRat", "cheese" },
        {"RedHatRat", "chesee"},
        {"ArthasRat", "cheese" }
    };


    internal void StartRatInitialize()
    {
        if (PlayerPrefs.GetInt("DoubleStripeRat") == 0)
        {
            PlayerPrefs.SetInt("DoubleStripeRat", 1);
        }
        else return;
    }

    internal void OnRatBuy()
    {
        var currentRatName = RatSwitcher.rats[RatSwitcher.currentRat];

        if ( Money.cheese >= ratsPrice.GetValueOrDefault(currentRatName))
        {
            Money.ReduceCheese(ratsPrice.GetValueOrDefault(currentRatName));
            PlayerPrefs.SetInt(currentRatName, 1);
            RatShopController.onHide?.Invoke();
            MoneyController.onMoneyShows?.Invoke();
        }
    }



}
