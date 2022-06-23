using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : WeaponAbility
{
    protected override void TurnOnWeaponAbility()
    {
        StartCoroutine(HealRat());
    }
    protected static IEnumerator HealRat()
    {
        if (HealthBar.healthPoints <= HealthBar.maximumHealth * 0.92f)
        {
            HealthBar.healthPoints += HealthBar.maximumHealth * 0.08f;
        }
        yield return new WaitForSeconds(10);
    }
}
