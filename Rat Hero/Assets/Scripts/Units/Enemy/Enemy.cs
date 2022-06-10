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
        OnPlayerInSight += LookTowardsPlayers;
        OnGetDamaged += GetDamage;
            
    }

    private void Update()
    {
        PlayerInSight();
    }

    protected override void Run()
    {
        rigidBody.velocity = (player.transform.GetChild(0).transform.position - transform.position).normalized * speed;
    }

    protected virtual void PlayerInSight()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if (distanceToPlayer < 8)
        {
            OnPlayerInSight?.Invoke();
        }
    }

    protected override void GetDamage(float playerDamage)
    {
        healthPoints -= playerDamage;
    }

    private void LookTowardsPlayers()
    {
        transform.LookAt(player.GetComponentsInChildren<Transform>()[0].transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent(WeaponInitializer.instance.weaponsValues.GetValueOrDefault(Weapon.currentWeapon).GetType()) != null)
        {
            OnGetDamaged(player.damage);
            Debug.Log(healthPoints);
            Debug.Log(player.damage);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Character>() != null)
        {
            OnApplyDamage?.Invoke(damage);
            Destroy(gameObject);
        }
    }



}
