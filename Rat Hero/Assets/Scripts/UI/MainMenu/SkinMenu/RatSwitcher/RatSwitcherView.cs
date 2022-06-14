using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RatSwitcherView : MonoBehaviour
{
    internal Button leftButton;
    internal Button rightButton;
    internal Button selectButton;

    private void Awake()
    {
        GetButtons();
    }

    internal void GetButtons()
    {
        var buttons = gameObject.GetComponentsInChildren<Button>();
        leftButton = buttons[0];
        rightButton = buttons[1];
        selectButton = buttons[2];
    }


}
