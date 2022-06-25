using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlock : WeaponShot
{

    private void Start()
    {
        speed = 8;
        MoveToDirection();
        StartCoroutine(WaitForDestroy());
    }
    protected override void DoEnemyCollision(Collision collision, Enemy enemy)
    {
        enemy.OnGetDamaged?.Invoke(player.damage);
        if (enemy != null)
        {
            StartCoroutine(ReduceEnemySpeed(enemy));
        }
    }

    private IEnumerator ReduceEnemySpeed(Enemy enemy)
    {
        enemy.currentSpeed = enemy.speed / 2;
        yield return new WaitForSeconds(Weapon.currentLevel + 1);
        if (enemy != null)
        {
            enemy.currentSpeed = enemy.speed;
        }
    }

    private IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
    }
}
