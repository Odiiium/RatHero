using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : WeaponAbility
{
    private int poisonTime = 2;

    protected override void TurnOnWeaponAbility()
    {
        Enemy.onSpecificWeaponAbilityUsed += DoPoisonEnemy;
    }

    private void OnDisable()
    {
        Enemy.onSpecificWeaponAbilityUsed -= DoPoisonEnemy;
    }

    private void DoPoisonEnemy(Enemy enemy)
    {
        if (!enemy.isPoisoned)
        {
            enemy.isPoisoned = true;
            StartCoroutine(WaitForPoison(enemy));
        }
    }

    private IEnumerator WaitForPoison(Enemy enemy)
    {
        if (enemy != null)
        {
            for (int i = 0; i < Weapon.currentLevel * poisonTime; i++)
            {
                yield return new WaitForSeconds(1);
                if (enemy == null) break;
                enemy.healthPoints -= Mathf.Round(player.damage * .3f);
            }
        }
    }


}
