using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : Enemy
{
    protected override float TimeToDeathSoundPlay { get => 2; }

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
            player.StartCoroutine(WaitForAttackAnimationEnds());
            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        hasAttacked = true;
        yield return new WaitForSeconds(6);
        hasAttacked = false;
    }

    private void ShootTheDirt()
    {
        MoleShot dirt = Instantiate(PieceOfDirt(), transform.position +  Vector3.up * .5f, transform.rotation);
        dirt.parentEnemy = this;
    }

    protected override void PushAwayFromPlayer()
    {
        Vector3 fromPlayerToEnemyDirection = (transform.position - player.transform.position).normalized;
        rigidBody.AddForce((fromPlayerToEnemyDirection * 400), ForceMode.Force);
    }

    private MoleShot PieceOfDirt()
    {
        return Resources.Load<MoleShot>("Prefabs/Units/Enemy/EnemyShots/MoleShot");
    }

    private IEnumerator WaitForAttackAnimationEnds()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        if (this) ShootTheDirt();
    }
}
