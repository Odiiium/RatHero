using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuController : MonoBehaviour
{
    [SerializeField] SettingsMenu settingsMenu;
    [SerializeField] SettingsMenuView settingsMenuView;

    private void Awake()
    {
        settingsMenuView.InitializeUIElements();
        settingsMenuView.backButton.onClick.AddListener(settingsMenu.BackToMenu);
        settingsMenuView.musicSlider.onValueChanged.AddListener(settingsMenu.ChangeMusicVolume);
        settingsMenuView.soundSlider.onValueChanged.AddListener(settingsMenu.ChangeSoundVolume);
    }


}
