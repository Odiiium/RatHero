using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponStatsView : MonoBehaviour
{
    TextMeshProUGUI statsText;
    TextMeshProUGUI addStatsText;

    internal void InitializeStatsUI()
    {
        statsText = gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        addStatsText =  gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
    }

    internal void SetStats()
    {
        WeaponSwitcher weaponSwitcher = FindObjectOfType<WeaponSwitcher>();
        string currentWeaponName = weaponSwitcher.weapons[WeaponSwitcher.currentWeapon];
        float[] weaponStatsArray = WeaponStats.weaponStatsValues.GetValueOrDefault(currentWeaponName);

        if (PlayerPrefs.GetInt(currentWeaponName) > 0)
        {
            statsText.text = "+" + weaponStatsArray[PlayerPrefs.GetInt(currentWeaponName) - 1] + "%";
            if (PlayerPrefs.GetInt(currentWeaponName) < 3)
            {
                addStatsText.gameObject.SetActive(true);
                addStatsText.text = "+" + (weaponStatsArray[PlayerPrefs.GetInt(currentWeaponName)] - weaponStatsArray[PlayerPrefs.GetInt(currentWeaponName) - 1]) + "%";
            }
            else { addStatsText.gameObject.SetActive(false); }
        }
        else
        {
            statsText.text = "+" + weaponStatsArray[PlayerPrefs.GetInt(currentWeaponName)] + "%";
            if (PlayerPrefs.GetInt(currentWeaponName) < 3)
            {
                addStatsText.gameObject.SetActive(true);
                addStatsText.text = "+" + (weaponStatsArray[PlayerPrefs.GetInt(currentWeaponName) + 1] - weaponStatsArray[PlayerPrefs.GetInt(currentWeaponName)]) + "%";
            }
            else { addStatsText.gameObject.SetActive(false); }
        }

    }
}
