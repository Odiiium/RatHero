using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : Unit
{
    [SerializeField] MobileController mobileJoystick;

    public static UnityAction onHealthChanged;
    public static UnityAction onManaChanged;

    private void OnEnable()
    {
        speed = (PlayerStats.Speed + RatAdditionalStats.ratStatsValues.GetValueOrDefault(RatSwitcher.rats[RatSwitcher.currentRat])[4] * PlayerStats.Speed) / 60;
        rotateSpeed = .7f;
        damage = PlayerStats.Damage + RatAdditionalStats.ratStatsValues.GetValueOrDefault(RatSwitcher.rats[RatSwitcher.currentRat])[0] * PlayerStats.Damage + WeaponStats.weaponStatsValues.GetValueOrDefault(Weapon.choisedWeapon)[Weapon.currentLevel - 1];

        Enemy.OnApplyDamage += GetDamage;
    }

    private void OnDisable()
    {
        Enemy.OnApplyDamage -= GetDamage;
    }

    private void Update()
    {
        Run();
    }

    protected override void Run()
    {
        rigidBody.velocity = transform.forward * mobileJoystick.yAxis() * speed;
        transform.Rotate(0, mobileJoystick.xAxis() * rotateSpeed, 0);
    }

    protected override void GetDamage(float enemyDamage)
    {
        HealthBar.healthPoints -= enemyDamage;
        onHealthChanged?.Invoke();
    }
}
