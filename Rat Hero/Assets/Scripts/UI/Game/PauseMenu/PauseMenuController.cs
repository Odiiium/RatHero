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
        AddListenersToUIElements();
    }

    private void AddListenersToUIElements()
    {
        pauseMenuView.musicScrollbar.onValueChanged.AddListener(SettingsMenu.ChangeMusicVolume);
        pauseMenuView.soundScrollbar.onValueChanged.AddListener(SettingsMenu.ChangeSoundVolume);
        pauseMenuView.fieldOfViewScrollbar.onValueChanged.AddListener(SettingsMenu.ChangeFieldOfView);
        pauseMenuView.exitButton.onClick.AddListener(pauseMenu.ExitGame);
        pauseMenuView.resumeGameButton.onClick.AddListener(pauseMenu.BackToGame);
    }
}
