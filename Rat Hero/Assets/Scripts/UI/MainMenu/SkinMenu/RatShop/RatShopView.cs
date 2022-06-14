using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;


public class RatShopView : MonoBehaviour
{
    internal TextMeshProUGUI priceText;
    GameObject priceObject;
    public static GameObject isLockedImage;
    internal Button buyButton;

    public static UnityAction onBuy;

    internal void InitializeUIElements()
    {
        buyButton = gameObject.transform.GetChild(0).GetComponent<Button>();
        priceObject = gameObject.transform.GetChild(1).gameObject;
        priceText = gameObject.transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        isLockedImage = gameObject.transform.GetChild(2).gameObject;
    }

    internal void HideUIElements()
    {
        buyButton.gameObject.SetActive(false);
        priceObject.gameObject.SetActive(false);
        isLockedImage.gameObject.SetActive(false);
    }

    internal void ShowUIElements()
    {
        buyButton.gameObject.SetActive(true);
        priceObject.gameObject.SetActive(true);
        isLockedImage.gameObject.SetActive(true);
        SetPrice();
    }

    internal void SetPrice()
    {
        RatSwitcher ratSwitcher = FindObjectOfType<RatSwitcher>(); 
        priceText.text = "" + RatShop.ratsPrice.GetValueOrDefault(ratSwitcher.rats[RatSwitcher.currentRat]);
    }
}
