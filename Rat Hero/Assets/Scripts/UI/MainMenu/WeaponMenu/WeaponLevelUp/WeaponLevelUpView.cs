using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponLevelUpView : MonoBehaviour
{
    internal Button levelUpButton;
    internal TextMeshProUGUI priceCount;
    internal void GetButton()
    {
        levelUpButton = gameObject.transform.GetChild(1).GetComponent<Button>();
    }

    internal void GetPrice()
    {
        levelUpButton.gameObject.SetActive(true);
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        priceCount = gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        SetPrice();
    }

    internal void SetPrice()
    {
        string currentWeaponName = WeaponSwitcher.weapons[WeaponSwitcher.currentWeapon];

        if (PlayerPrefs.GetInt(currentWeaponName) > 0 & PlayerPrefs.GetInt(currentWeaponName) < 3)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            priceCount.text = "" + WeaponLevelUp.lvlUpPriceValues.GetValueOrDefault(currentWeaponName)[PlayerPrefs.GetInt(currentWeaponName) - 1];
        }
        else 
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
