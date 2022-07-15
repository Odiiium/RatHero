using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLizardShot : EnemyShot
{
    protected override float SpeedModifier { get => 1.7f; }

    protected override void DoDamageAction(Enemy enemy)
    {
        base.DoDamageAction(enemy);
        playerTransform.GetComponentInParent<Character>().StartCoroutine(ApplyFireDamage(enemy));
    }

    IEnumerator ApplyFireDamage(Enemy enemy)
    {
        CreateBurningParticle(out BurnParticle burningParticle);
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1);
            ChangePlayerHealthPoints((int)(enemy.damage / 3));
        }
        Destroy(burningParticle.gameObject);
    }

    BurnParticle BurnParticle()
    {
        return Resources.Load<BurnParticle>("Prefabs/Particles/BurningParticle");
    }

    void CreateBurningParticle(out BurnParticle burn)
    {
        BurnParticle burningParticle = Instantiate(BurnParticle(), playerTransform.position, Quaternion.identity);
        burningParticle.followedObjectTransform = playerTransform;
        burn = burningParticle;
    }
}
