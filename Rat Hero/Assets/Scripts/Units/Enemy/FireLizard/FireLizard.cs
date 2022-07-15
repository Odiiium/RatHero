using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLizard : Enemy
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
            CastFireball();
            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        hasAttacked = true;
        yield return new WaitForSeconds(5);
        hasAttacked = false;
    }

    private void CastFireball()
    {
        FireLizardShot fireball = Instantiate(Fireball(), transform.position, transform.rotation);
        fireball.parentEnemy = this;
        fireball.transform.rotation = transform.rotation;
    }

    private FireLizardShot Fireball()
    {
        return Resources.Load<FireLizardShot>("Prefabs/Units/Enemy/EnemyShots/FireLizardShot");
    }
}
