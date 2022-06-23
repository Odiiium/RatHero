using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static string choisedWeapon { get { return PlayerPrefs.GetString("choisedWeapon"); } set { PlayerPrefs.SetString("choisedWeapon", value); }}

    public static int currentLevel { get { return PlayerPrefs.GetInt(choisedWeapon);} set { PlayerPrefs.SetInt(choisedWeapon, value); } }

    private void Awake()
    {
        WeaponInitializer.OnLoaded += InstanceInitialize;
    }

    private void OnDisable()
    {
        WeaponInitializer.OnLoaded -= InstanceInitialize;
    }

    protected void RotateAroundPlayer()
    {
        transform.RotateAround(this.transform.parent.position, Vector3.up, PlayerStats.AttackSpeed / 50);
    }


    private void Update()
    {
        RotateAroundPlayer();
    }

    private void InstanceInitialize()
    {
        WeaponInitializer.instance.InitializeWeapon(choisedWeapon, currentLevel);
    }
}
