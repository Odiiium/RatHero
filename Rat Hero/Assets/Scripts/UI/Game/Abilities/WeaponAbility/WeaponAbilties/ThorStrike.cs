using System.Collections;
using UnityEngine;

public class ThorStrike : WeaponAbility
{
    private float timeModifier = 15; 

    protected override void TurnOnWeaponAbility()
    {
        player.StartCoroutine(MakeStrike());
    }

    private IEnumerator MakeStrike()
    {
        yield return new WaitForSeconds(AbilityCooldown());
        Collider[] enemiesNearPlayer = Physics.OverlapSphere(player.transform.position, StrikeRadius());
        DamageAllEnemiesAroundPlayer(enemiesNearPlayer);
        StartCoroutine(MakeStrike());
    }

    private void DamageAllEnemiesAroundPlayer(Collider[] enemies)
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].gameObject.TryGetComponent(out Enemy currentEnemy))
            {
                currentEnemy.OnGetDamaged?.Invoke((int)player.damage * 0.8f);
            }
        }
    }

    private float StrikeRadius()
    {
        return (Weapon.currentLevel * 3 + 1) / 2;
    }

    private int AbilityCooldown()
    {
        return (int)((timeModifier / Weapon.currentLevel) + 2);
    }
}