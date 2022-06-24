using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlock : WeaponShot
{
    private float speed;
    [SerializeField] Character player;

    protected override void DoEnemyCollision(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.OnDamage(player.damage);
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
}
