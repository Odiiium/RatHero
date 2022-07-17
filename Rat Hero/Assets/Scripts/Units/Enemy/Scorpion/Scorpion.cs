using System.Collections;
using UnityEngine;

public class Scorpion : Enemy
{
    protected override float TimeToDeathSoundPlay { get => 3; }

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
        yield return new WaitForSeconds(4);
        hasAttacked = false;
    }

    private void ShootTheThorn()
    {
        ScorpionShot thorn = Instantiate(Thorn(), transform.position + Vector3.up * .3f, transform.rotation);
        thorn.parentEnemy = this;
    }

    protected override void PushAwayFromPlayer()
    {
        Vector3 fromPlayerToEnemyDirection = (transform.position - player.transform.position).normalized;
        rigidBody.AddForce((fromPlayerToEnemyDirection * 400), ForceMode.Force);
    }

    private ScorpionShot Thorn()
    {
        return Resources.Load<ScorpionShot>("Prefabs/Units/Enemy/EnemyShots/ScorpionShot");
    }

    private IEnumerator WaitForAttackAnimationEnds()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        if (this) ShootTheThorn();
    }
}
