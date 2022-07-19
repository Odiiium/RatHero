using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatShop : MonoBehaviour
{
    private const string cheese = "cheese";
    private const string diamonds = "diamonds";

    public static Dictionary<string, int> ratsPrice = new Dictionary<string, int>() // Dictionary which contains price 
    {
        {"AlbinoRat",   100 },
        {"RedHatRat",   200 },
        {"ArthasRat",   400 },
        {"WomenRat",    750 },
        {"PunkRat",     1400},
        {"MerlinRat",   2250},
        {"CarRat",      3000},
        {"PharaohRat",  4500},
        {"UFORat",      6000},
        {"KingRat",     10000}
    };

    public static Dictionary<string, string> moneyType = new Dictionary<string, string>() // Dictionary which contains currency ( cheese or diamonds )
    {
        {"AlbinoRat",   cheese},
        {"RedHatRat",   cheese},
        {"ArthasRat",   cheese},
        {"WomenRat",    cheese},
        {"PunkRat",     cheese},
        {"MerlinRat",   cheese},
        {"CarRat",      cheese},
        {"PharaohRat",  cheese},
        {"UFORat",      cheese},
        {"KingRat",     cheese},
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
