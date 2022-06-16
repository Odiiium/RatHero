using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShop : MonoBehaviour
{
    public static Dictionary<string, int> weaponsPrice = new Dictionary<string, int>() // Dictionary which contains price 
    {
        {"Pistol", 100 },
        {"PoisonedKnife", 200 },
        {"Sword", 200 }
    };

    public static Dictionary<string, string> weaponsType = new Dictionary<string, string>() // Dictionary which contains currency ( cheese or diamonds )
    {
        {"Pistol", "cheese" },
        {"PoisonedKnife", "cheese" },
        {"Sword", "cheese" }
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
        WeaponSwitcher weaponSwitcher = FindObjectOfType<WeaponSwitcher>();
        var currentWeaponName = weaponSwitcher.weapons[WeaponSwitcher.currentWeapon];

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
