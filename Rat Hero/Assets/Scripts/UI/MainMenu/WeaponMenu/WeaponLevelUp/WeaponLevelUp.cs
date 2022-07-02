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
        {"Claws",               new int[2]{500, 1400}    },
        {"Scepter",             new int[2]{450, 1150}    },
        {"Katana",              new int[2]{800, 1600}    },
        {"DruidStaff",          new int[2]{1000, 2000}    },
        {"Bow",                 new int[2]{1500, 2900}    },
        {"ArcaneGun",           new int[2]{2200, 4200}    },
    };

    internal void WeaponLevelingUp()
    {
        string currentWeaponName = WeaponSwitcher.weapons[WeaponSwitcher.currentWeapon];
        int currentWeaponLvlUpPrice = lvlUpPriceValues.GetValueOrDefault(currentWeaponName)[PlayerPrefs.GetInt(currentWeaponName) - 1];

        if (Money.cheese > currentWeaponLvlUpPrice & PlayerPrefs.GetInt(currentWeaponName) < 3)
        {
            PlayerPrefs.SetInt(currentWeaponName, PlayerPrefs.GetInt(currentWeaponName) + 1);
            Money.ReduceCheese(currentWeaponLvlUpPrice);
            WeaponLevelUpController.onWeaponChanging?.Invoke();
            WeaponStatsController.onStatsDisplay?.Invoke();
            WeaponShopController.onHide?.Invoke();
        }
    }
}
