using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneButtons : MonoBehaviour
{
    [SerializeField] GameObject weaponMenu;
    [SerializeField] GameObject skinMenu;
    [SerializeField] GameObject mainCameras;

    internal void GoToSkinMenu()
    {
        SwitchCameras();
        OpenSkinMenu();
    }

    private void SwitchCameras()
    {
        mainCameras.transform.GetChild(0).gameObject.SetActive(true);
        mainCameras.transform.GetChild(1).gameObject.SetActive(false);
    }
    
    private void OpenSkinMenu()
    {
        weaponMenu.gameObject.SetActive(false);
        skinMenu.gameObject.SetActive(true);
    }

    internal void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

}
