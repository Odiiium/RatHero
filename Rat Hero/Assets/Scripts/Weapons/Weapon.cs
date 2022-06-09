using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected string weaponName { get; set; }
    protected float damage { get; set; }

    protected Rigidbody weaponRigidbody;
    protected BoxCollider weaponCollider;

    static Weapon instance;
    protected void StatsInitialize(float Damage, string Name)
    {
        damage = Damage;
        name = Name;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            if (gameObject.name == "Weapon")
            {
                WeaponInitializer.instance.InitialWeapon("PoisonedKnife", 2);
            }
        }
        else
        {
            return;
        }
    }

    protected void RotateAroundPlayer()
    {
        transform.RotateAround(this.transform.parent.position, Vector3.up, 2);

    }

    protected virtual void Attack()
    {

    }

}
