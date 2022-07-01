using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : ActiveBuff
{
    internal override void DoBuff()
    {
        if (ManaBar.mana <= ManaBar.maximumMana * 0.75f)
        {
            ManaBar.mana += Mathf.Round(ManaBar.maximumMana * 0.25f) - 1;
        }
        else ManaBar.mana = ManaBar.maximumMana;
        Character.onManaChanged?.Invoke();
    }
}
