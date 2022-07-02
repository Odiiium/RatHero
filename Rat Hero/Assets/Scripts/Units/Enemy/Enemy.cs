using UnityEngine;
using UnityEngine.Events;

public class Enemy : Unit
{
    Character player;
    Transform playerSkinTransform;
    Animator animator;


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
        animator = transform.GetChild(0).GetComponent<Animator>();
        player = FindObjectOfType<Character>();
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
            OnPlayerInSight?.Invoke();
        }
    }

    protected override void GetDamage(float playerDamage)
    {
        healthPoints -= playerDamage;
    }

    private void LookTowardsPlayers()
    {
        transform.LookAt(playerSkinTransform.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Weapon>() != null)
        {
            animator.SetTrigger("Hurt");
            OnGetDamaged(player.damage + player.Crit());
            onSpecificWeaponAbilityUsed?.Invoke(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Character>() != null)
        {
            animator.SetTrigger("Hurt");
            OnApplyDamage?.Invoke(damage);
            PushAwayFromPlayer();
            OnGetDamaged(player.damage + player.Crit());
        }
    }

    private void PushAwayFromPlayer()
    {
        Vector3 playerToEnemyDirection = (transform.position - player.transform.position).normalized;

        if (speed != 0) rigidBody.AddForce((playerToEnemyDirection * 300), ForceMode.Force);
        else rigidBody.AddForce((playerToEnemyDirection * 100), ForceMode.Force);
    }

    private void SubscribeEvents()
    {
        OnPlayerInSight += Run;
        OnPlayerInSight += LookTowardsPlayers;
        OnGetDamaged += GetDamage;
    }

    private void UnSubscribeEvents()
    {
        OnPlayerInSight -= Run;
        OnPlayerInSight -= LookTowardsPlayers;
        OnGetDamaged -= GetDamage;
    }

}
