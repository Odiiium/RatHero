using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaRegenerationBuff : PassiveBuff
{
    internal override void DoBuff()
    {
        player.StartCoroutine(RegenerateMana());
    }

    internal override IEnumerator WaitForBuffEnds()
    {
        yield return new WaitForSeconds(1);
    }

    private IEnumerator RegenerateMana()
    {
        for (int i = 0; i < 15; i++)
        {
            if (ManaBar.mana <= ManaBar.maximumMana * 0.95)
            {
                ManaBar.mana += Mathf.Round(ManaBar.maximumMana * 0.05f) - 1;
            }
            else ManaBar.mana = ManaBar.maximumMana;

            Character.onManaChanged?.Invoke();
            yield return new WaitForSeconds(1);
        }
    }
}
