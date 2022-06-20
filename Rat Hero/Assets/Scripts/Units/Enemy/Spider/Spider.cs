using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    private bool hasAttacked;

    private void Awake()
    {
        hasAttacked = false;
        OnPlayerInSight += Attack;
        healthPoints = 1200;
        damage = 40;
        speed = 0;
    }

    protected override void Attack()
    {
        if (!hasAttacked)
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
        SpiderShoot spidershoot = Instantiate(Resources.Load<SpiderShoot>("Prefabs/Units/Enemy/EnemyAbilities/SpiderShoot"), transform.position, transform.rotation);
        spidershoot.parentSpider = this;
        spidershoot.transform.rotation = transform.rotation;
    }
}
