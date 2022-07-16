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
        SettingsMenu.onSoundChange?.Invoke(SettingsMenu.Sound.volume);
        SettingsMenu.onMusicChange?.Invoke(SettingsMenu.Music.volume);
    }

    private void OnEnable()
    {
        AddListeners();
    }

    private void OnDisable()
    {
        RemoveListeners();
    }


    private void AddListeners()
    {
        settingsMenuView.backButton.onClick.AddListener(settingsMenu.BackToMenu);
        settingsMenuView.musicSlider.onValueChanged.AddListener(SettingsMenu.ChangeMusicVolume);
        settingsMenuView.soundSlider.onValueChanged.AddListener(SettingsMenu.ChangeSoundVolume);

        SettingsMenu.onMusicChange += settingsMenuView.SetMusicScrollbarValues;
        SettingsMenu.onSoundChange += settingsMenuView.SetSoundScrollbarValues;
    }

    private void RemoveListeners()
    {
        settingsMenuView.backButton.onClick.RemoveAllListeners();
        settingsMenuView.musicSlider.onValueChanged.RemoveAllListeners();
        settingsMenuView.soundSlider.onValueChanged.RemoveAllListeners();

        SettingsMenu.onMusicChange -= settingsMenuView.SetMusicScrollbarValues;
        SettingsMenu.onSoundChange -= settingsMenuView.SetSoundScrollbarValues;
    }
}
