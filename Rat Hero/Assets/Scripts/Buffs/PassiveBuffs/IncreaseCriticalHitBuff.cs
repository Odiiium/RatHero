using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseCriticalHitBuff : PassiveBuff
{
    internal override void DoBuff()
    {
        player.criticalChance += 15;
    }

    internal override IEnumerator WaitForBuffEnds()
    {
        yield return new WaitForSeconds(15);
        player.criticalChance -= 15;
    }
}
