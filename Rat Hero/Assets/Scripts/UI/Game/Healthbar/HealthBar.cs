using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    internal static float healthPoints
    {   get { return hp; }
        set
        {
            hp = value;
            if (hp <= 0)
            {
                PauseMenu.isGame = false;
                PostGameMenu.isDied?.Invoke();
            }
        }
    }

    private static float hp;

    internal static float maximumHealth { get; set; }

    internal void SetHealthPoints()
    {

        float additionalHealthPoints = RatAdditionalStats.ratStatsValues.GetValueOrDefault(RatSwitcher.rats[RatSwitcher.currentRat])[1] * PlayerStats.HealthPoints / 100;
        maximumHealth = PlayerStats.HealthPoints + additionalHealthPoints;
        healthPoints = maximumHealth;
    }

}
