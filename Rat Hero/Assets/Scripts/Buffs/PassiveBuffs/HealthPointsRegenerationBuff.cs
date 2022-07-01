using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPointsRegenerationBuff : PassiveBuff
{
    internal override void DoBuff()
    {
        player.StartCoroutine(RegenerateHealthPoints());
    }

    internal override IEnumerator WaitForBuffEnds()
    {
        yield return new WaitForSeconds(1);
    }

    private IEnumerator RegenerateHealthPoints()
    {
        for (int i = 0; i < 15; i++)
        {
            if (HealthBar.healthPoints <= HealthBar.maximumHealth * 0.93)
            {
                HealthBar.healthPoints += Mathf.Round(HealthBar.maximumHealth * 0.07f) - 1;
            }
            else HealthBar.healthPoints = HealthBar.maximumHealth;

            Character.onHealthChanged?.Invoke();
            yield return new WaitForSeconds(1);
        }
    }
}
