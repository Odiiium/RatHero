using System.Collections;
using UnityEngine;

public class ScorpionShot : EnemyShot
{
    protected override float SpeedModifier { get => 2.6f;}

    protected override void DoDamageAction(Enemy enemy)
    {
        base.DoDamageAction(enemy);
        playerTransform.GetComponent<Skin>().StartCoroutine(DoPoison());

    }

    private IEnumerator DoPoison()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(2);
            ChangePlayerHealthPoints((int)parentEnemy.damage / 5);
        }
    }


}
