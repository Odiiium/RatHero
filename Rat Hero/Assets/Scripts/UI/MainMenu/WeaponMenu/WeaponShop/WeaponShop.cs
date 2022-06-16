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
}
