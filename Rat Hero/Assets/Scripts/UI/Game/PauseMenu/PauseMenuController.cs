using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] PauseMenu pauseMenu;
    [SerializeField] PauseMenuView pauseMenuView;

    private void Awake()
    {
        pauseMenuView.InitializeUI();
    }

    private void OnEnable()
    {
        AddListenersToUIElements();
        SettingsMenu.onSoundChange?.Invoke(SettingsMenu.Sound.volume);
        SettingsMenu.onMusicChange?.Invoke(SettingsMenu.Music.volume);
    }

    private void OnDisable()
    {
        RemoveListenersToUIElements();
    }

    private void AddListenersToUIElements()
    {
        pauseMenuView.musicScrollbar.onValueChanged.AddListener(SettingsMenu.ChangeMusicVolume);
        pauseMenuView.soundScrollbar.onValueChanged.AddListener(SettingsMenu.ChangeSoundVolume);
        pauseMenuView.fieldOfViewScrollbar.onValueChanged.AddListener(SettingsMenu.ChangeFieldOfView);
        pauseMenuView.exitButton.onClick.AddListener(pauseMenu.ExitGame);
        pauseMenuView.resumeGameButton.onClick.AddListener(pauseMenu.BackToGame);

        SettingsMenu.onMusicChange += pauseMenuView.SetMusicScrollbarValues;
        SettingsMenu.onSoundChange += pauseMenuView.SetSoundScrollbarValues;
    }

    private void RemoveListenersToUIElements()
    {
        pauseMenuView.musicScrollbar.onValueChanged.RemoveAllListeners();
        pauseMenuView.soundScrollbar.onValueChanged.RemoveAllListeners();
        pauseMenuView.fieldOfViewScrollbar.onValueChanged.RemoveAllListeners();
        pauseMenuView.exitButton.onClick.RemoveAllListeners();
        pauseMenuView.resumeGameButton.onClick.RemoveAllListeners();

        SettingsMenu.onMusicChange -= pauseMenuView.SetMusicScrollbarValues;
        SettingsMenu.onSoundChange -= pauseMenuView.SetSoundScrollbarValues;
    }
}
