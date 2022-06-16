using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalButtonsController : MonoBehaviour
{
    [SerializeField] AdditionalButtons additionalButtons;
    [SerializeField] AdditionalButtonView additionalButtonsView;

    private void Awake()
    {
        additionalButtonsView.GetButton();
        additionalButtonsView.settingMenuButton.onClick.AddListener(additionalButtons.GoToSettingsMenu);
        additionalButtonsView.exitButton.onClick.AddListener(additionalButtons.ExitGame);
    }


}
