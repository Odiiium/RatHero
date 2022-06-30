using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDamageBuff : PassiveBuff
{
    internal override void DoBuff()
    {
        Debug.Log(player.damage);
        player.damage *= 2;
        Debug.Log(player.damage);
    }

    internal override IEnumerator WaitForBuffEnds()
    {
        yield return new WaitForSeconds(15);
        player.damage /= 2;
        Debug.Log(player.damage);
    }
}
