using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected string weaponName { get; set; }
    protected float damage { get; set; }

    protected Rigidbody weaponRigidbody;
    protected BoxCollider weaponCollider;
    protected Character player;

    protected void StatsInitialize(float Damage, string Name)
    {
        damage = Damage;
        name = Name;
    }

    private void Awake()
    {
        player = FindObjectOfType<Character>();
    }

    protected virtual void RotateAroundPlayer()
    {
        transform.RotateAround(player.transform.position, Vector3.up, 2);
    }

    protected virtual void Attack()
    {

    }

}
