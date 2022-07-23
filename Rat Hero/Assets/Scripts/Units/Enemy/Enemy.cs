using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Unit
{
    protected Character player;
    protected Transform playerSkinTransform;
    protected Animator animator;
    internal EnemySpawnPoint enemySpawnPoint;

    internal UnityAction<float> OnGetDamaged;

    internal static UnityAction<float> OnApplyDamage;
    internal static UnityAction<Enemy> onSpecificWeaponAbilityUsed;

    private bool isDied;
    
    internal override float healthPoints
    {
        get { return currentHp; }
        set
        {
            currentHp = value;
            if (currentHp <= 0 && !isDied)
            {
                isDied = true;
                OnDie();
            }
        }
    }

    protected virtual float TimeToGedDamagedSoundPlay { get => 0; }
    protected virtual float TimeToDeathSoundPlay { get => 0; }

    //Set dependents to Enemy
    private void OnEnable()
    {
        isDied = false;
        player = FindObjectOfType<Character>();
        InitializeEnemyStats();
        animator = transform.GetChild(0).GetComponent<Animator>();
        playerSkinTransform = player.GetComponentsInChildren<Transform>()[0];
        SubscribeEvents();
    }

    private void OnDisable()
    {
        UnSubscribeEvents();
    }

    // Checking is player on sight or not 
    private void Update()
    {
       PlayerInSight();
    }

    // Run if game is not paused
    protected override void Run()
    {
        if (PauseMenu.isGame)
        {
            Vector3 moveDirection = player.transform.position - transform.position;
            transform.position += moveDirection.normalized * speed / 175;
        }
    }

    protected virtual void OnDie()
    {
        AddCheeseForPlayer();
        soundsEffects.OnDeathMakeSound(TimeToDeathSoundPlay);
        PostGameMenu.killedEnemies++;
        if (enemySpawnPoint)                        //Checking is enemy were created by using spawnPoint 
        {
            enemySpawnPoint.enemyCount--;
            enemySpawnPoint.onEnemyHasBeenKilled?.Invoke();
        }
        SpawnManager.onEnemyDies?.Invoke();
        Destroy(gameObject);
    }

    // Add cheese depends on maximal hp of enemy, invokes Adding cheese action
    private void AddCheeseForPlayer()
    {
        Money.AddCheese(Mathf.RoundToInt(maxHp / 1000) + 1);
        PostGameMenu.cheeseGained += Mathf.RoundToInt(maxHp / 1000) + 1;
        Money.onCheeseAdding?.Invoke();
    }

    //Checking is player in Enemy sight or not 
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

    //Reduce healthpoints and set "Hurt" animation when enemy get damaged by player
    protected override void GetDamage(float playerDamage)
    {
        if (this)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Hurt")) animator.SetTrigger("Hurt"); // Checking is hurt animation playing or not
            soundsEffects.OnGetDamagedMakeSound(TimeToGedDamagedSoundPlay);
            healthPoints -= playerDamage;
        }
    }

    private void LookTowardsPlayer()
    {
        transform.LookAt(playerSkinTransform.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Weapon>() && this && PauseMenu.isGame)
        {
            OnGetDamaged(player.damage + player.Crit());        //Call action that damages enemy
            onSpecificWeaponAbilityUsed?.Invoke(this);          //Call action that uses special weapon ability to an enemy if allowed
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Character player) && this && PauseMenu.isGame)
        {
            PushAwayFromPlayer();
            OnApplyDamage?.Invoke(damage);                      //Call action that damages a player
            try
            {
                int pureDamage = (int)player.damage + (int)player.Crit();
                OnGetDamaged(pureDamage);
            }
            catch { }
        }
    }

    protected virtual void PushAwayFromPlayer()
    {
        Vector3 fromPlayerToEnemyDirection = (transform.position - player.transform.position).normalized;

        if (speed != 0) rigidBody.AddForce((fromPlayerToEnemyDirection * 300), ForceMode.Force);        //Check is enemy is not kinematic
        else rigidBody.AddForce((fromPlayerToEnemyDirection * 100), ForceMode.Force);                   //If true adding bigger force to an enemy
    }

    private void SubscribeEvents()
    {
        OnGetDamaged += GetDamage;
    }

    private void UnSubscribeEvents()
    {
        OnGetDamaged -= GetDamage;
    }

    // Get enemy stats in dictionary and initialize it depending on Enemy type
    private void InitializeEnemyStats()
    {
        float[] enemyStats = EnemyStatsDictionary.enemiesStats.GetValueOrDefault(GetType().ToString());     
        BasicStatsInitialize(enemyStats);
        maxHp = healthPoints;
        currentSpeed = speed;
    }

    //Set peculiar stats depending on time player has played
    private void BasicStatsInitialize(float[] enemyStats)
    {
        speed = enemyStats[2];

        if (PostGameMenu.timeAlived > 600)
        {
            healthPoints = (int)Mathf.Pow(enemyStats[0], TimeModifier()) + 500 + RatLevelUp.CurrentLvl * 40;
            damage = (int)Mathf.Pow(enemyStats[1], TimeModifier()) + 50 + RatLevelUp.CurrentLvl * 8;
        }
        else
        {
            healthPoints = (int)Mathf.Pow(enemyStats[0], TimeModifier()) + RatLevelUp.CurrentLvl * 30;
            damage = (int)enemyStats[1] + RatLevelUp.CurrentLvl * 5;
        }
    }

    private float TimeModifier()
    {
        float alivedTime = PostGameMenu.timeAlivedInMinutes()[0];

        return 1 + (alivedTime / 30);
    }
}
