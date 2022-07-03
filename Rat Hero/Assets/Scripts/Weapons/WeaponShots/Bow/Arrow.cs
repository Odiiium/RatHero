using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : WeaponShot
{
    private void Start()
    {
        speed = 12;
        MoveToDirection();
        StartCoroutine(WaitForDestroy());
    }
    protected override void DoEnemyCollision(Collision collision, Enemy enemy)
    {
        enemy.OnGetDamaged?.Invoke((player.damage + player.Crit()));
    }

    private IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(1.8f);
        Destroy(gameObject);
    }
}
