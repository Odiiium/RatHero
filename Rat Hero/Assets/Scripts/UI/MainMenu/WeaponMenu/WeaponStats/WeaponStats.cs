using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public static Dictionary<string, float[]> weaponStatsValues = new Dictionary<string, float[]>()
    {
        {"Axe",                 new float[3]    {5, 10, 18}  }, //Damage,  AttackSp,  HP,  Defence,  Speed,  CritChance,  Mana
        {"Sword",               new float[3]    {7, 13, 23}  },
        {"Pistol",              new float[3]    {5, 11, 20}  },
        {"PoisonedKnife",       new float[3]    {10, 15, 25} }      
    };



}
