using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Unit
{
    Character player;

    protected UnityAction OnPlayerInSight;
    private UnityAction<float> OnGetDamaged;
    public UnityAction<float> OnDamage;

    internal static UnityAction<float> OnApplyDamage;

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
        rigidBody.velocity = (player.transform.GetChild(0).transform.position - transform.position).normalized * speed;
    }

    protected virtual void OnDie()
    {
        Money.AddCheese(Mathf.RoundToInt(maxHp / 1000) + 1);
        Money.onCheeseAdding();
        SpawnManager.enemyCount--;
        SpawnManager.onEnemyDies();
        Destroy(gameObject);
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
            OnGetDamaged(player.damage);
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
