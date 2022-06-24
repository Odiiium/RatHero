using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyPersistance : WeaponAbility
{
    int baseHealTime = 10;
    int startHealTimeDelay = 6;
    int levelDelayTime = 2;

    protected override void TurnOnWeaponAbility()
    {
        StartCoroutine(HealRat(Weapon.currentLevel));
    }

    private IEnumerator HealRat(int level)
    {
        if (HealthBar.healthPoints <= HealthBar.maximumHealth * (1 - 0.03f * level))
        {
            HealthBar.healthPoints += Mathf.Round(HealthBar.maximumHealth * level * 0.03f);
            Character.onHealthChanged?.Invoke();
        }
        yield return new WaitForSeconds(baseHealTime + (startHealTimeDelay - level * levelDelayTime));
        StartCoroutine(HealRat(Weapon.currentLevel));
    }
}
