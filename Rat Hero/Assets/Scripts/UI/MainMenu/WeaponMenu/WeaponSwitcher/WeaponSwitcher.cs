using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] internal string[] weapons;

    static public int currentWeapon { get { return PlayerPrefs.GetInt("currentWeapon"); } set { PlayerPrefs.SetInt("currentWeapon", value); } }

    static public void FindWeaponInArray()
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
            DisplayWeapon();

        }
        else
        {
            weaponInitializer.InitializeMenuWeapons(weapons[weapons.Length - 1]);
            currentWeapon = weapons.Length - 1;
            DisplayWeapon();
        }
    }

    internal void SwitchToRight()
    {
        WeaponInitializer weaponInitializer = FindObjectOfType<WeaponInitializer>();
        if (currentWeapon != weapons.Length - 1)
        {
            weaponInitializer.InitializeMenuWeapons(weapons[currentWeapon + 1]);
            currentWeapon++;
            DisplayWeapon();
        }
        else
        {
            weaponInitializer.InitializeMenuWeapons(weapons[0]);
            currentWeapon = 0;
            DisplayWeapon();
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
    private void DisplayWeapon()
    {
        if (PlayerPrefs.GetInt(weapons[currentWeapon]) > 0) WeaponShopController.onHide?.Invoke();
        else WeaponShopController.onShow?.Invoke();
        DisplayWeaponStats();
    }

    private void DisplayWeaponStats()
    {
        WeaponAbilitiesController.onWeaponChanged?.Invoke();
        WeaponLevelUpController.onWeaponChanging?.Invoke();
        WeaponStatsController.onStatsDisplay?.Invoke();
    }
}