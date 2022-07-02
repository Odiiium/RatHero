using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShop : MonoBehaviour
{
    public static Dictionary<string, int> weaponsPrice = new Dictionary<string, int>() // Dictionary which contains price 
    {
        {"Sword",               100 },
        {"Pistol",              250 },
        {"PoisonedKnife",       250 },
        {"Claws",               450 },
        {"Scepter",             500 },
        {"Katana",              650 },
        {"DruidStaff",          850},
        {"Bow",                 1200},
        {"ArcaneGun",           1800},
    };

    public static Dictionary<string, string> weaponsType = new Dictionary<string, string>() // Dictionary which contains currency ( cheese or diamonds )
    {
        {"Sword",               "cheese" },
        {"PoisonedKnife",       "cheese" },
        {"Pistol",              "cheese" },
        {"Claws",               "cheese" },
        {"Scepter",             "cheese" },
        {"Katana",              "cheese" },
        {"DruidStaff",          "cheese" },
        {"Bow",                 "cheese" },
        {"ArcaneGun",           "cheese" },
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
