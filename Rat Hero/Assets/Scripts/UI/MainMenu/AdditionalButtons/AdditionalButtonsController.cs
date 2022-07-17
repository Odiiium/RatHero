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
    }
    private void OnEnable()
    {
        additionalButtonsView.settingMenuButton.onClick.AddListener(additionalButtons.GoToSettingsMenu);
        additionalButtonsView.exitButton.onClick.AddListener(additionalButtons.ExitGame);
    }

    private void OnDisable()
    {
        additionalButtonsView.settingMenuButton.onClick.RemoveAllListeners();
        additionalButtonsView.exitButton.onClick.RemoveAllListeners();
    }


}
