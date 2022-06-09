using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponName { get; protected set; }
    public float damage { get; protected set; }

     Weapon instance;

    public static string currentWeapon;

    protected void StatsInitialize(float Damage, string Name)
    {
        damage = Damage;
        name = Name;
    }

    private void Awake()
    {
        currentWeapon = "Sword";
        WeaponInitializer.OnLoaded += InstanceInitialize;
    }

    protected void RotateAroundPlayer()
    {
        transform.RotateAround(this.transform.parent.position, Vector3.up, 2);

    }

    protected virtual void Attack()
    {

    }

    private void InstanceInitialize()
    {
        if (instance == null)
        {
            instance = this;
            if (gameObject.name == "Weapon")
            {
                WeaponInitializer.instance.InitializeWeapon(currentWeapon, 2);
            }
        }
        else
        {
            return;
        }
    }

}
