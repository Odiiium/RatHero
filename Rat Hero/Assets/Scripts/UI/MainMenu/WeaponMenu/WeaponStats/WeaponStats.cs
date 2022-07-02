using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public static Dictionary<string, float[]> weaponStatsValues = new Dictionary<string, float[]>()
    {
        {"Axe",                 new float[3]    {5, 10, 18}     }, // Damage ( Lvl1, Lvl2, Lvl3)
        {"Sword",               new float[3]    {7, 13, 23}     },
        {"Pistol",              new float[3]    {5, 11, 20}     },
        {"PoisonedKnife",       new float[3]    {10, 15, 25}    },
        {"Claws",               new float[3]    {14, 20, 27}    },
        {"Scepter",             new float[3]    {10, 14, 22}    },
        {"Katana",              new float[3]    {15, 22, 32}    },
        {"DruidStaff",          new float[3]    {15, 19, 25}    },
        {"Bow",                 new float[3]    {25, 35, 45}    },
        {"ArcaneGun",           new float[3]    {22, 28, 35}    },
    };



}
