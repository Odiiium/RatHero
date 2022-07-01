using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDefenceBuff : PassiveBuff
{
    internal override void DoBuff()
    {
        player.defence += 60;
    }

    internal override IEnumerator WaitForBuffEnds()
    {
        yield return new WaitForSeconds(15);
        player.defence -= 60;
    }
}
