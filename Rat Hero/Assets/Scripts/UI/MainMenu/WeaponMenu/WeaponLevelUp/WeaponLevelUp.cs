using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLevelUp : MonoBehaviour
{
    public static Dictionary<string, int[]> lvlUpPriceValues = new Dictionary<string, int[]>()
    {
        {"Axe",                 new int[2]{50, 250}     },
        {"Sword",               new int[2]{100, 350}    },
        {"Pistol",              new int[2]{200, 500}    },
        {"PoisonedKnife",       new int[2]{300, 800}    },
    };

    internal void WeaponLevelingUp()
    {
        string currentWeaponName = FindObjectOfType<WeaponSwitcher>().weapons[WeaponSwitcher.currentWeapon];
        int currentWeaponLvlUpPrice = lvlUpPriceValues.GetValueOrDefault(currentWeaponName)[PlayerPrefs.GetInt(currentWeaponName) - 1];

        if (Money.cheese > currentWeaponLvlUpPrice & PlayerPrefs.GetInt(currentWeaponName) < 3)
        {
            PlayerPrefs.SetInt(currentWeaponName, PlayerPrefs.GetInt(currentWeaponName) + 1);
            Money.ReduceCheese(currentWeaponLvlUpPrice);
            WeaponLevelUpController.onWeaponChanging?.Invoke();
            WeaponShopController.onHide?.Invoke();
        }
    }




}
