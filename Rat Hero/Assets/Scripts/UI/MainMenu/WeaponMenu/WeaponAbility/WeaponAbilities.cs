using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAbilities : MonoBehaviour
{
    public static Dictionary<string, string[]> abilityInfoValues = new Dictionary<string, string[]>
    {
        {"Axe", new string[2]           { "Berserker",          "The rat goes berserker and gain more damage but less health points"        } },
        {"Sword", new string[2]         { "Holy persistance",   "The rat heal himself every 10 seconds. Heal grows by level"                } },
        {"Pistol", new string[2]        { "Shrapnel",           "Sometimes the rat shoots toward enemies. Depends on your Attack Speed"     } },
        {"PoisonedKnife", new string[2] { "Poison",             "Your attacks poison the victim for 5 seconds. Poison damage stacks"        } },
        {"Claws", new string[2]         { "Bloodlust",          "For each kill you increase damage by 1% up to 50%"                         } },
        {"Scepter", new string[2]       { "Snowstorm",          "Summons ice blocks toward enemies"                                         } },
        {"Katana", new string[2]        { "Light Pace",         "Passively increases your speed and attack speed for 30%"                   } }
    };
}
