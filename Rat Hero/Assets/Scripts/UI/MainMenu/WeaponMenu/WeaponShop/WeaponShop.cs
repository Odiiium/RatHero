using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShop : MonoBehaviour
{
    public static Dictionary<string, int> weaponsPrice = new Dictionary<string, int>() // Dictionary which contains price 
    {
        {"Sword",               100 },
        {"Pistol",              200 },
        {"PoisonedKnife",       200 },
        {"Claws",               350 },
        {"Scepter",             400 },
        {"Katana",              500 }
    };

    public static Dictionary<string, string> weaponsType = new Dictionary<string, string>() // Dictionary which contains currency ( cheese or diamonds )
    {
        {"Sword",               "cheese" },
        {"PoisonedKnife",       "cheese" },
        {"Pistol",              "cheese" },
        {"Claws",               "cheese" },
        {"Scepter",             "cheese" },
        {"Katana",              "cheese" }
    };
    internal void StartWeaponInitialize()
    {
        if (PlayerPrefs.GetInt("Axe") == 0)
        {
            PlayerPrefs.SetInt("Axe", 1);
        }
        else return;
    }

    internal void OnWeaponBuy()
    {
        var currentWeaponName = WeaponSwitcher.weapons[WeaponSwitcher.currentWeapon];

        if (Money.cheese >= weaponsPrice.GetValueOrDefault(currentWeaponName))
        {
            Money.ReduceCheese(weaponsPrice.GetValueOrDefault(currentWeaponName));
            PlayerPrefs.SetInt(currentWeaponName, 1);
            WeaponShopController.onHide?.Invoke();
            MoneyController.onMoneyShows?.Invoke();
            WeaponLevelUpController.onWeaponChanging?.Invoke();
        }
    }
}
