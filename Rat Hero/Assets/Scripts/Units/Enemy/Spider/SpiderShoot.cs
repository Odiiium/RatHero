using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShoot : EnemyShot
{
    protected override float SpeedModifier { get => 2.0f; }

    private void SpawnSpiderWeb()
    {
        Instantiate(spiderWeb(), transform.position, transform.rotation);
    }

    protected override void DoDestroyAction()
    {
        SpawnSpiderWeb();
        base.DoDestroyAction();
    }

    private SpiderWeb spiderWeb()
    {
        return Resources.Load<SpiderWeb>("Prefabs/Units/Enemy/EnemyAbilities/SpiderWeb");
    }


}
