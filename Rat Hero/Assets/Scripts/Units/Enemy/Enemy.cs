using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Unit
{
    Character player;

    protected UnityAction OnPlayerInSight;
    internal UnityAction<float> OnGetDamaged;

    internal static UnityAction<float> OnApplyDamage;
    internal static UnityAction<Enemy> onSpecificWeaponAbilityUsed;

    internal override float healthPoints
    {
        get { return currentHp; }
        set
        {
            currentHp = value;
            if (currentHp <= 0)
            {
                OnDie();
            }
        }
    }

    private void OnEnable()
    {
        maxHp = healthPoints;
        player = FindObjectOfType<Character>();
        OnPlayerInSight += Run;
        OnPlayerInSight += LookTowardsPlayers;
        OnGetDamaged += GetDamage;
    }

    private void OnDisable()
    {
        OnPlayerInSight -= Run;
        OnPlayerInSight -= LookTowardsPlayers;
        OnGetDamaged -= GetDamage;
    }

    private void Update()
    {
        PlayerInSight();
    }

    protected override void Run()
    {
        if (PauseMenu.isGame)
        {
            rigidBody.velocity = (player.transform.GetChild(0).transform.position - transform.position).normalized * speed;
        }
    }

    protected virtual void OnDie()
    {
        AddCheeseForPlayer();
        PostGameMenu.killedEnemies++;
        SpawnManager.enemyCount--;
        SpawnManager.onEnemyDies();
        Destroy(gameObject);
    }

    private void AddCheeseForPlayer()
    {
        Money.AddCheese(Mathf.RoundToInt(maxHp / 1000) + 1);
        PostGameMenu.cheeseGained += Mathf.RoundToInt(maxHp / 1000) + 1;
        Money.onCheeseAdding();
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
        if (other.gameObject.GetComponent<Weapon>() != null)
        {
            OnGetDamaged(player.damage + player.Crit());
            onSpecificWeaponAbilityUsed?.Invoke(this);
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
