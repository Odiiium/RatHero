using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class WeaponShopView : MonoBehaviour
{
    private Image[] lockImages;
    internal Button buyButton;
    private GameObject priceObject;
    private TextMeshProUGUI priceText;

    public static UnityAction onBuy;

    internal void InitializeUIElements()
    {
        buyButton = gameObject.transform.GetChild(0).GetComponent<Button>();
        priceObject = gameObject.transform.GetChild(1).gameObject;
        priceText = gameObject.transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        lockImages = gameObject.transform.GetChild(2).GetComponentsInChildren<Image>();
    }

    internal void HideUIElements()
    {
        WeaponSwitcher weaponSwitcher= FindObjectOfType<WeaponSwitcher>();
        if (PlayerPrefs.GetInt(weaponSwitcher.weapons[WeaponSwitcher.currentWeapon]) != 0) ShowUIElements();

        buyButton.gameObject.SetActive(false);
        priceObject.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt(weaponSwitcher.weapons[WeaponSwitcher.currentWeapon]) == 0)
        {
            return;
        }
        else
        {
            for (int i =  0; i < PlayerPrefs.GetInt(weaponSwitcher.weapons[WeaponSwitcher.currentWeapon]); i++)
            {
                lockImages[i].gameObject.SetActive(false);
            }
        }
    }

    internal void ShowUIElements()
    {
        WeaponSwitcher weaponSwitcher = FindObjectOfType<WeaponSwitcher>();
        buyButton.gameObject.SetActive(true);
        priceObject.gameObject.SetActive(true);
        if (PlayerPrefs.GetInt(weaponSwitcher.weapons[WeaponSwitcher.currentWeapon]) == 3)
        {
            return;
        }
        else
        {
            for (int i = 0; i < 3 - PlayerPrefs.GetInt(weaponSwitcher.weapons[WeaponSwitcher.currentWeapon]); i++)
            {
                lockImages[2 - i].gameObject.SetActive(true);
            }
        }
        SetPrice();
    }

    internal void SetPrice()
    {
        WeaponSwitcher weaponSwitcher = FindObjectOfType<WeaponSwitcher>();
        priceText.text = "" + WeaponShop.weaponsPrice.GetValueOrDefault(weaponSwitcher.weapons[WeaponSwitcher.currentWeapon]);
    }

}
