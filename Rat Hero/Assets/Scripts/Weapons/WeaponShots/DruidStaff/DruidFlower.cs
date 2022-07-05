using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruidFlower : MonoBehaviour
{
    internal Character player;

    private void Awake()
    {
        StartCoroutine(DestroyFlower());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            ReduceEnemyStats(enemy);
            Destroy(gameObject);
        }
    }

    private void ReduceEnemyStats(Enemy enemy)
    {
        enemy.OnGetDamaged(player.damage * 3);
        enemy.currentSpeed /= 1.6f;
    }

    private IEnumerator DestroyFlower()
    {
        yield return new WaitForSeconds(20);
        Destroy(gameObject);
    }
}
