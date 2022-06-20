using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject pauseMenu;

    internal void OpenPauseMenu()
    {
        PauseMenu.isGame = false;
        gameUI.SetActive(false);
        pauseMenu.SetActive(true);
    }

}
