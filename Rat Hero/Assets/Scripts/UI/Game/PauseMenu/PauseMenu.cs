using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameUI;

    internal static bool isGame;

    internal void BackToGame()
    {
        pauseMenu.SetActive(false);
        gameUI.SetActive(true);
        isGame = true;
        
    }

    internal void ExitGame()
    {
        isGame = true;
        SceneManager.LoadScene("Menu");
    }

}
