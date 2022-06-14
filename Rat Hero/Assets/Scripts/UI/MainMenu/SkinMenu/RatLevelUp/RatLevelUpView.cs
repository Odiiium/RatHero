using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RatLevelUpView : MonoBehaviour
{
    internal Button levelUpButton;
    internal TextMeshProUGUI priceCount;
    [SerializeField] TextMeshProUGUI ratLevel;
    internal void GetButton()
    {
        levelUpButton = gameObject.transform.GetChild(1).GetComponent<Button>();
    }

    internal void GetPrice()
    {
        priceCount = gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
        SetPrice();
    }

    public static void ShowLevel()
    {
        FindObjectOfType<RatLevel>().transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = RatLevelUp.CurrentLvl + " LVL";
    }
    internal void SetPrice()
    {
        priceCount.text = "" + Mathf.Pow(RatLevelUp.CurrentLvl, 2);
    }

}
