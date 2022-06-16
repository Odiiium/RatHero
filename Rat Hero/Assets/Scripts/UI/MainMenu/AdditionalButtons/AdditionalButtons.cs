using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalButtons : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject mainCameras;

    internal void GoToSettingsMenu()
    {
        SwitchCameras();
        OpenSettingsMenu();
    }
    internal void ExitGame()
    {
        Application.Quit();
    }

    private void SwitchCameras()
    {
        for (int i = 0; i < 2; i++) mainCameras.transform.GetChild(i).gameObject.SetActive(false);
        mainCameras.transform.GetChild(2).gameObject.SetActive(true);
    }

    private void OpenSettingsMenu()
    {
        mainMenu.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(true);
    }

}
