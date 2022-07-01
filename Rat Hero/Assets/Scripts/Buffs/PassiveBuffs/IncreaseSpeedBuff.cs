using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSpeedBuff : PassiveBuff
{
    internal override void DoBuff()
    {
        player.currentSpeed *= 1.4f;
    }

    internal override IEnumerator WaitForBuffEnds()
    {
        yield return new WaitForSeconds(15);
        player.currentSpeed /= 1.4f;
    }
}
