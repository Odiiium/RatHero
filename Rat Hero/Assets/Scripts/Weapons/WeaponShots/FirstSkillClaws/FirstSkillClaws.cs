using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSkillClaws : WeaponShot
{
    private void Start()
    {
        speed = 8;
        MoveFromPlayer();
        StartCoroutine(WaitForDestroy());
    }
    protected override void DoEnemyCollision(Collision collision, Enemy enemy)
    {
        enemy.OnGetDamaged?.Invoke(player.damage);
    }

    private IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }

    private void MoveFromPlayer()
    {
        Vector3 moveDirection = transform.up;
        rigidBody.AddForce(moveDirection * speed, ForceMode.Impulse);
    }    
}
