using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : Unit
{
    [SerializeField] MobileController mobileJoystick;

    internal static bool isGrounded;

    public static UnityAction onHealthChanged;
    public static UnityAction onManaChanged;
    internal float defence { get; set; }
    internal float attackSpeed { get; set; }
    internal float criticalChance { get; set; }

    private void Awake()
    {
        isGrounded = true;
        SetPlayerStats();
        Enemy.OnApplyDamage += GetDamage;
    }

    private void OnDisable()
    {
        Enemy.OnApplyDamage -= GetDamage;
    }

    private void Update()
    {
        if (PauseMenu.isGame)
        {
            PostGameMenu.timeAlived += Time.deltaTime;
            Run();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != 6)
        {
            isGrounded = true;
        }
    }

    private void SetPlayerStats()
    {
        attackSpeed = InitializedPlayerAttackSpeed();
        speed = InitializedPlayerSpeed() / 60;
        damage = InitializedPlayerDamage();
        criticalChance = InitializedPlayerCriticalChance();
        defence = InitializedPlayerDefence();

        currentSpeed = speed;
        rotateSpeed = .7f;
    }

    protected override void Run()
    {
        if (mobileJoystick.yAxis() != 0 && isGrounded)
        {
            rigidBody.velocity = transform.forward * mobileJoystick.yAxis() * currentSpeed;
        }
            transform.Rotate(0, mobileJoystick.xAxis() * rotateSpeed, 0);
    }

    protected override void GetDamage(float enemyDamage)
    {
        float blockModifier = 1 - defence / 400;
        HealthBar.healthPoints -= Mathf.Round(enemyDamage * blockModifier);
        onHealthChanged?.Invoke();
    }


    float InitializedPlayerDamage()
    {
        float weaponAdditionalDamage = WeaponStats.weaponStatsValues.GetValueOrDefault(Weapon.choisedWeapon)[Weapon.currentLevel - 1] * PlayerStats.Damage / 100;
        float ratAdditionalDamage = RatAdditionalStats.ratStatsValues.GetValueOrDefault(RatSwitcher.rats[RatSwitcher.currentRat])[0] * PlayerStats.Damage / 100;
        return Mathf.Round(PlayerStats.Damage + ratAdditionalDamage + weaponAdditionalDamage);
    }

    float InitializedPlayerDefence()
    {
        float ratAdditionalDefence = RatAdditionalStats.ratStatsValues.GetValueOrDefault(RatSwitcher.rats[RatSwitcher.currentRat])[3] * PlayerStats.Defence / 100;
        return PlayerStats.Defence + ratAdditionalDefence;
    }

    float InitializedPlayerAttackSpeed()
    {
        float ratAdditionalAttackSpeed = RatAdditionalStats.ratStatsValues.GetValueOrDefault(RatSwitcher.rats[RatSwitcher.currentRat])[1] * PlayerStats.AttackSpeed / 100;
        return PlayerStats.AttackSpeed + ratAdditionalAttackSpeed;
    }

    float InitializedPlayerSpeed()
    {
        float ratAdditionalSpeed = RatAdditionalStats.ratStatsValues.GetValueOrDefault(RatSwitcher.rats[RatSwitcher.currentRat])[4] * PlayerStats.Speed / 100;
        return PlayerStats.Speed + ratAdditionalSpeed;
    }

    float InitializedPlayerCriticalChance()
    {
        float ratAdditionalCriticalChance = RatAdditionalStats.ratStatsValues.GetValueOrDefault(RatSwitcher.rats[RatSwitcher.currentRat])[5] * PlayerStats.CriticalChance / 100;
        return PlayerStats.CriticalChance + ratAdditionalCriticalChance;
    }

    internal float Crit()
    {
        int randomInt = Random.Range(0, 100);
        if (randomInt < criticalChance)
        {
            return damage * 1.5f;
        }
        else return 0;
    }

}
