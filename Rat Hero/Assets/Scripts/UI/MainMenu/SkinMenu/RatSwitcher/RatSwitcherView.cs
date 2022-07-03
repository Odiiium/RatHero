using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class RatSwitcherView : MonoBehaviour
{
    internal Button leftButton;
    internal Button rightButton;
    internal Button selectButton;

    static TextMeshProUGUI ratNameText;


    private void Awake()
    {
        GetButtons();
        InitializeRatName();
    }

    internal void GetButtons()
    {
        var buttons = gameObject.GetComponentsInChildren<Button>();
        leftButton = buttons[0];
        rightButton = buttons[1];
        selectButton = buttons[2];
    }

    internal static void SetRatName()
    {
        ratNameText.text = RatSwitcher.rats[RatSwitcher.currentRat].ToString();
    }

    private void InitializeRatName()
    {
        ratNameText = transform.parent.GetChild(0).GetComponent<TextMeshProUGUI>();
        ratNameText.text = PlayerPrefs.GetString("choisedRat", RatSwitcher.rats[RatSwitcher.currentRat]);
    }


}
