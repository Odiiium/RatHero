using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : ActiveBuff
{
    internal override void DoBuff()
    {
        if (HealthBar.healthPoints <= HealthBar.maximumHealth * 0.75f)
        {
            HealthBar.healthPoints += Mathf.Round(HealthBar.maximumHealth * 0.25f) - 1;
        }
        else HealthBar.healthPoints = HealthBar.maximumHealth;
        Character.onHealthChanged?.Invoke();
    }

}
