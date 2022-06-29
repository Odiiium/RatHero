using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : MonoBehaviour
{
    internal static float mana {get;set;}
    internal static float maximumMana { get; set; }

    internal void SetManaPoints()
    {
        float additionalMana = RatAdditionalStats.ratStatsValues.GetValueOrDefault(RatSwitcher.rats[RatSwitcher.currentRat])[6] * PlayerStats.Mana / 100;

        maximumMana = PlayerStats.Mana + additionalMana;
        mana = maximumMana;
    }

    internal void RegenerateMana()
    {
        if (mana <= maximumMana * 0.985f)
        {
            mana += Mathf.Round(maximumMana * 0.015f);
            if (mana > maximumMana)
            {
                mana = maximumMana;
            }
        }
        else mana = maximumMana;
        Character.onManaChanged?.Invoke();
    }

}
