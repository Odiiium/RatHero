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
        ratLevelText().text = RatLevelUp.CurrentLvl + " LVL";
    }
    internal void SetPrice()
    {
        if (RatLevelUp.CurrentLvl < 80)
        {
            priceCount.text = "" + (int)Mathf.Pow(RatLevelUp.CurrentLvl, 1.7f);
        }
        else
        {
            priceCount.text = "" + (int)Mathf.Pow(RatLevelUp.CurrentLvl, 2);
        }
    }

    private static TextMeshProUGUI ratLevelText()
    {
        return FindObjectOfType<RatLevel>().transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

}
