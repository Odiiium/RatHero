using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : WeaponShot
{
    private void Start()
    {
        speed = 15;
        MoveToDirection();
        StartCoroutine(WaitForDestroy());
    }
    protected override void DoEnemyCollision(Collision collision, Enemy enemy)
    {
        enemy.OnGetDamaged?.Invoke(player.damage * .6f);
    }

    private IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
    }
}
