using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodLust : WeaponAbility
{
    int killedEnemiesCount;
    float playerDamageModifier = 0.01f;

    private void OnEnable()
    {
        SpawnManager.onEnemyDies += IncreaseCounter;
    }

    private void OnDisable()
    {
        SpawnManager.onEnemyDies -= IncreaseCounter;
    }

    private void IncreaseCounter()
    {
        killedEnemiesCount++;
        AddAdditionalDamageForPlayer();
    }

    private void AddAdditionalDamageForPlayer()
    {
        if (killedEnemiesCount <= 50)
        {
            if (Mathf.Round(player.damage * playerDamageModifier) >= 1)
            {
                player.damage += Mathf.Round(player.damage * playerDamageModifier);
            }
            else player.damage += 1;
        }
        else return;
    }
}
