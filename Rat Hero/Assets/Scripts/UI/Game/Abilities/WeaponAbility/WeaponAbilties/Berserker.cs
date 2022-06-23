using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker : WeaponAbility
{
    protected override void TurnOnWeaponAbility()
    {
        HealthBar.maximumHealth = Mathf.Round(HealthBar.maximumHealth / 1.25f);
        HealthBar.healthPoints = Mathf.Round(HealthBar.healthPoints / 1.25f);
        Character.onHealthChanged?.Invoke();
        player.damage = Mathf.Round(player.damage * 1.25f);
    }

}
