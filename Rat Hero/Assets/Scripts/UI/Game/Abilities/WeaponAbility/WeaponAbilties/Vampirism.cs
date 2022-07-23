using System.Collections;
using UnityEngine;

public class Vampirism : WeaponAbility
{
    private float vampirismModifier = 0.015f;

    private void OnEnable()
    {
        TurnOnWeaponAbility();
    }

    private void OnDisable()
    {
        SpawnManager.onEnemyDies -= HealTheRat;
    }

    protected override void TurnOnWeaponAbility()
    {
        SpawnManager.onEnemyDies += HealTheRat;
    }

    private void HealTheRat()
    {
        int healthToHeal = (int)(HealthBar.maximumHealth * vampirismModifier * Weapon.currentLevel);
        if (HealthBar.healthPoints <= HealthBar.maximumHealth - healthToHeal)
        {
            HealthBar.healthPoints += healthToHeal;
            Character.onHealthChanged?.Invoke();
        }
        else HealthBar.healthPoints = HealthBar.maximumHealth;
    }

}