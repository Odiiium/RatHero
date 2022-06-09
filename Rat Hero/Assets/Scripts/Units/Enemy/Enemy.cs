using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] Character player;

    private delegate void OnSee();
    public delegate void OnDamage(float damage);

    private event OnSee OnPlayerInSight;
    private event OnDamage OnGetDamaged;
    internal static event OnDamage OnApplyDamage;

    private void OnEnable()
    {
        OnPlayerInSight += Run;
        OnGetDamaged += GetDamage;
            
    }

    private void Update()
    {
        OnPlayerInSight();
    }

    protected override void Run()
    {
        rigidBody.velocity = (player.transform.position - transform.position).normalized * speed;
    }

    protected virtual void PlayerInSight()
    {
        if (Mathf.Abs(player.transform.position.x-transform.position.x) < 8 | Mathf.Abs(player.transform.position.z - transform.position.z) < 8)
        {
            OnPlayerInSight();
        }
    }

    protected override void GetDamage(float playerDamage)
    {
        healthPoints -= playerDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent(WeaponInitializer.instance.weaponsValues.GetValueOrDefault(Weapon.currentWeapon).GetType()) != null)
        {
            OnGetDamaged(player.damage);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Character>() != null)
        {
            OnApplyDamage(damage);
        }
    }



}
