using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAdditionalStats : MonoBehaviour
{
    public static Dictionary<string, float[]> ratStatsValues = new Dictionary<string, float[]>()
    {
        {"DoubleStripeRat",     new float[7]    {8, 12, 8, 0, 0, 0, 0}          }, //Damage,  AttackSp,  HP,  Defence,  Speed,  CritChance,  Mana
        {"AlbinoRat",           new float[7]    {0, 0, 15, 0, 4, 7, 0}          },
        {"RedHatRat",           new float[7]    {10, 5, 15, 0, 0, 0, 8}         },
        {"ArthasRat",           new float[7]    {0, 0, 0, 8, 0, 20, 0}          },
        {"WomenRat",            new float[7]    {0, 25, 0, 0, 15, 0, 0}         },
        {"PunkRat",             new float[7]    {40, 0, 0, 0, 0, 10, 0}         },
        {"MerlinRat",           new float[7]    {15, 0, 0, 0, 0, 0, 50}         },
        {"CarRat",              new float[7]    {30, 0, 20, 20, 30, 0, 0}       },
        {"PharaohRat",          new float[7]    {30, 30, 0, 0, 0, 0, 50}        },
        {"UFORat",              new float[7]    {40, 30, 30, 20, 20, 0, 20}     },
        {"AngelRat",            new float[7]    {40, 40, 40, 15, 40, 0, 75}     },
        {"DemonRat",            new float[7]    {40, 75, 40, 15, 40, 0, 40}     },
        {"KingRat",             new float[7]    {50, 50, 50, 50, 50, 50, 50}    },
        {"GodzillaRat",         new float[7]    {120, 30, 120, 100, 0, 30, 0}   },
    };

}
