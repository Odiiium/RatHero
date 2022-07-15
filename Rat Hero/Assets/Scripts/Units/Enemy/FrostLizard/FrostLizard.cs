using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostLizard : Enemy
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
            CastIceball();
            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        hasAttacked = true;
        yield return new WaitForSeconds(5);
        hasAttacked = false;
    }

    private void CastIceball()
    {
        FrostLizardShot iceball = Instantiate(Iceball(), transform.position, transform.rotation);
        iceball.parentEnemy = this;
        iceball.transform.rotation = transform.rotation;
    }

    private FrostLizardShot Iceball()
    {
        return Resources.Load<FrostLizardShot>("Prefabs/Units/Enemy/EnemyShots/FrostLizardShot");
    }
}
