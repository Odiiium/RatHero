using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] internal string[] weapons;

    static public int currentWeapon { get {return PlayerPrefs.GetInt("currentWeapon"); } set { PlayerPrefs.SetInt("currentWeapon", value);}}

    static public void  FindWeaponInArray()
    {
        WeaponSwitcher weaponSwitcher = FindObjectOfType<WeaponSwitcher>();
        for (int i = 0; i < weaponSwitcher.weapons.Length; i++)
        {
            if (weaponSwitcher.weapons[i] == Weapon.choisedWeapon)
            {
                currentWeapon = i;
                return;
            }
        }
    }

    internal void SwitchToLeft()
    {
        WeaponInitializer weaponInitializer = FindObjectOfType<WeaponInitializer>();
        if (currentWeapon != 0)
        {
            weaponInitializer.InitializeMenuWeapons(weapons[currentWeapon - 1]);
            currentWeapon--;
        }
        else
        {
            weaponInitializer.InitializeMenuWeapons(weapons[weapons.Length - 1]);
            currentWeapon = weapons.Length - 1;
        }
    }

    internal void SwitchToRight()
    {
        WeaponInitializer weaponInitializer = FindObjectOfType<WeaponInitializer>();
        if (currentWeapon != weapons.Length - 1)
        {
            weaponInitializer.InitializeMenuWeapons(weapons[currentWeapon + 1]);
            currentWeapon++;
        }
        else
        {
            weaponInitializer.InitializeMenuWeapons(weapons[0]);
            currentWeapon = 0;
        }
    }

    internal void SelectWeapon()
    {
        if (PlayerPrefs.GetInt(weapons[currentWeapon]) != 0)
        {
            Weapon.choisedWeapon = weapons[currentWeapon];
        }
        else { Weapon.choisedWeapon = "Axe"; }
    }
}



    /*private void DisplayWeapon()
    {
        DisplayRatStats();
        if (PlayerPrefs.GetInt(rats[currentRat]) == 1) RatShopController.onHide?.Invoke();
        else RatShopController.onShow?.Invoke();
    }

    private void DisplayWeaponStats()
    {
        RatAdditionalStatsController.onStatsDisplay?.Invoke();
    }*/
