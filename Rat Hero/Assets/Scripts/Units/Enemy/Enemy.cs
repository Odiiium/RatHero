using UnityEngine;
using UnityEngine.Events;

public class Enemy : Unit
{
    Character player;
    Transform playerSkinTransform;
    Animator animator;

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
        animator = transform.GetChild(0).GetComponent<Animator>();
        playerSkinTransform = player.GetComponentsInChildren<Transform>()[0];
        SubscribeEvents();
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }

    private void Update()
    {
       PlayerInSight();
    }

    protected override void Run()
    {
        if (PauseMenu.isGame)
        {
            //rigidBody.velocity = (player.transform.GetChild(0).transform.position - transform.position).normalized * speed;
            Vector3 moveDirection = player.transform.position - transform.position;
            transform.position += moveDirection.normalized * speed / 175;
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
            Run();
            LookTowardsPlayer();
            Attack();
        }
    }

    protected override void GetDamage(float playerDamage)
    {
        animator.SetTrigger("Hurt");
        healthPoints -= playerDamage;
    }

    private void LookTowardsPlayer()
    {
        transform.LookAt(playerSkinTransform.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Weapon>())
        {
            OnGetDamaged(player.damage + player.Crit());
            onSpecificWeaponAbilityUsed?.Invoke(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Character player))
        {
            PushAwayFromPlayer();
            OnApplyDamage?.Invoke(damage);
            OnGetDamaged((int)player.damage + (int)player.Crit());
        }
    }

    private void PushAwayFromPlayer()
    {
        Vector3 fromPlayerToEnemyDirection = (transform.position - player.transform.position).normalized;

        if (speed != 0) rigidBody.AddForce((fromPlayerToEnemyDirection * 300), ForceMode.Force);
        else rigidBody.AddForce((fromPlayerToEnemyDirection * 100), ForceMode.Force);
    }

    private void SubscribeEvents()
    {
        OnGetDamaged += GetDamage;
    }

    private void UnSubscribeEvents()
    {
        OnGetDamaged -= GetDamage;
    }

}
