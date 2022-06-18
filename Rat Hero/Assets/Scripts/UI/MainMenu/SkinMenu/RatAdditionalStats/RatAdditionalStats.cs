using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAdditionalStats : MonoBehaviour
{
    public static Dictionary<string, float[]> ratStatsValues = new Dictionary<string, float[]>()
    {
        {"DoubleStripeRat",     new float[7]    {8, 12, 8, 0, 0, 0, 0}     }, //Damage,  AttackSp,  HP,  Defence,  Speed,  CritChance,  Mana
        {"AlbinoRat",           new float[7]    {0, 0, 15, 0, 4, 7, 0}     },
        {"RedHatRat",           new float[7]    {10, 5, 15, 0, 0, 0, 8}    },
        {"ArthasRat",           new float[7]    {0, 0, 0, 8, 0, 20, 0}     }  
    };

}
