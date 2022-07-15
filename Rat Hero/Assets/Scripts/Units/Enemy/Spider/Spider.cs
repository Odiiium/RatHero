using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
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
            SpitTheWeb();
            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        hasAttacked = true;
        yield return new WaitForSeconds(4);
        hasAttacked = false;
    }

    private void SpitTheWeb()
    {
        SpiderShoot spidershoot = Instantiate(SpiderShoot(), transform.position, transform.rotation);
        spidershoot.parentEnemy = this;
        spidershoot.transform.rotation = transform.rotation;
    }

    private SpiderShoot SpiderShoot()
    {
        return Resources.Load<SpiderShoot>("Prefabs/Units/Enemy/EnemyShots/SpiderShoot");
    }
}
