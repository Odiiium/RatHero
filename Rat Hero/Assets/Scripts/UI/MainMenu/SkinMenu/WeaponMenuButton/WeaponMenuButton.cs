using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponMenuButton : MonoBehaviour
{
    [SerializeField] GameObject SkinMenu;
    [SerializeField] GameObject WeaponMenu;
    [SerializeField] GameObject mainCameras;

    internal void GoToWeaponMenu()
    {
        SwitchCameras();
        OpenWeaponMenu();
    }

    private void SwitchCameras()
    {
        mainCameras.transform.GetChild(0).gameObject.SetActive(false);
        mainCameras.transform.GetChild(1).gameObject.SetActive(true);
    }

    private void OpenWeaponMenu()
    {
        SkinMenu.gameObject.SetActive(false);
        WeaponMenu.gameObject.SetActive(true);
    }
}
