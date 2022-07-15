using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostLizardShot : EnemyShot
{
    protected override float SpeedModifier { get => 1.7f; }

    protected override void DoDamageAction(Enemy enemy)
    {
        base.DoDamageAction(enemy);
        playerTransform.GetComponentInParent<Character>().StartCoroutine(ApplySlow(enemy));
    }

    IEnumerator ApplySlow(Enemy enemy)
    {
        if (!Character.isSlowed)
        {
            MakeSlowlessEffect(out IceParticle iceParticle, out Character player);
            yield return new WaitForSeconds(5);
            Character.isSlowed = false;
            player.currentSpeed *= 2;
            Destroy(iceParticle.gameObject);
        }
        else yield return null;
    }

    private void MakeSlowlessEffect(out IceParticle ice, out Character character)
    {
        Character player = playerTransform.parent.GetComponent<Character>();
        CreateIceParticle(out IceParticle iceParticle);
        ice = iceParticle;
        character = player;
        player.currentSpeed /= 2;
        Character.isSlowed = true;
    }

    IceParticle IceParticle()
    {
        return Resources.Load<IceParticle>("Prefabs/Particles/IceParticle");
    }

    void CreateIceParticle(out IceParticle ice)
    {
        IceParticle iceParticle = Instantiate(IceParticle(), playerTransform.position, Quaternion.identity);
        iceParticle.followedObjectTransform = playerTransform;
        ice = iceParticle;
    }
}
