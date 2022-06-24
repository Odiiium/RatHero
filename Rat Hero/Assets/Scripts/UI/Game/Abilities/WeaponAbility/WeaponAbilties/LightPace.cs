using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPace : WeaponAbility
{
    float speedModifier = 0.1f;
    protected override void TurnOnWeaponAbility()
    {
        player.speed += player.speed * Weapon.currentLevel * speedModifier;
        player.attackSpeed += player.attackSpeed * Weapon.currentLevel * speedModifier;
    }
}
