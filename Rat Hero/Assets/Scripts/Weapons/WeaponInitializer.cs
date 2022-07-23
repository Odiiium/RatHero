using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponInitializer : MonoBehaviour
{
    public static WeaponInitializer instance;

    public static UnityAction OnLoaded;

    private void Awake()
    {

        if (gameObject.name == "WeaponMenu")
        {
            BeginStartingInitalizeInWeaponMenu();
        }

        if (instance == null)
        {
            instance = this;
            OnLoaded?.Invoke();
        }
        else return;
    }

    internal void InitializeWeapon(string weaponName, int weaponLvl)
    {
        if (gameObject.transform.GetChild(0))
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject childObject = gameObject.transform.GetChild(i).gameObject;
                childObject.GetComponent<MeshFilter>().mesh = Resources.Load<Mesh>($"Mesh/Weapons/{weaponName}/{weaponName}_lvl{weaponLvl}");
                childObject.GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>($"Materials/Weapons/{weaponName}/{weaponName}");
            }
        }
        else return;
    }

    internal void InitializeMenuWeapons(string weaponName)
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject childObject = gameObject.transform.GetChild(i).gameObject;
            childObject.GetComponent<MeshFilter>().mesh = Resources.Load<Mesh>($"Mesh/Weapons/{weaponName}/{weaponName}_lvl{i+1}");
            childObject.GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>($"Materials/Weapons/{weaponName}/{weaponName}");
        }
    }
    
    private void BeginStartingInitalizeInWeaponMenu()
    {
        WeaponSwitcher.FindWeaponInArray();
        InitializeMenuWeapons(Weapon.choisedWeapon);
        WeaponShopController.onShow?.Invoke();
        WeaponShopController.onHide?.Invoke();
        WeaponAbilitiesController.onWeaponChanged?.Invoke();
    }

}
