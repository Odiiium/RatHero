using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hedgehog : Enemy
{
    private bool hasAttacked;

    private void Awake()
    {
        hasAttacked = false;
    }

    protected override void Attack()
    {
        if (!hasAttacked && PauseMenu.isGame)
        {
            animator.SetTrigger("Attack");
            ShootThorns();
            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        hasAttacked = true;
        yield return new WaitForSeconds(8);
        hasAttacked = false;
    }

    private void ShootThorns()
    {
        for (int i = 0; i < 8; i++)
        {
            HedgehogShot thorn = Instantiate(Thorn(), transform.position, transform.rotation * Quaternion.Euler(0, 45 * i, 0));
            thorn.parentEnemy = this;
        }
    }

    private HedgehogShot Thorn()
    {
        return Resources.Load<HedgehogShot>("Prefabs/Units/Enemy/EnemyShots/HedgehogShot");
    }
}
