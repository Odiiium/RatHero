using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    internal static float healthPoints { get; set; }
    internal static float maximumHealth { get; set; }

    internal void SetHealthPoints()
    {
        float additionalHealthPoints = RatAdditionalStats.ratStatsValues.GetValueOrDefault(RatSwitcher.rats[RatSwitcher.currentRat])[1] * PlayerStats.HealthPoints / 100;
        maximumHealth = PlayerStats.HealthPoints + additionalHealthPoints;
        healthPoints = maximumHealth;
    }

}
