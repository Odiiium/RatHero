using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDamageBuff : PassiveBuff
{
    internal override void DoBuff()
    {
        player.damage *= 2;
    }

    internal override IEnumerator WaitForBuffEnds()
    {
        yield return new WaitForSeconds(15);
        player.damage /= 2;
    }
}
