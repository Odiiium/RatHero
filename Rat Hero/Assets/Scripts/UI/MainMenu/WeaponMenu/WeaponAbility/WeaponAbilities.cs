using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAbilities : MonoBehaviour
{
    public static Dictionary<string, string[]> abilityInfoValues = new Dictionary<string, string[]>
    {
        {"Axe", new string[2]           { "Berserker",          "The rat goes berserker and gain additional 10/20/30% damage but lost 10/20/30% health points"        } },
        {"Sword", new string[2]         { "Holy persistance",   "The rat heal himself every 14/12/10 seconds for 3/6/9% from max health" } },
        {"Pistol", new string[2]        { "Shrapnel",           "Sometimes the rat shoots toward enemies. Depends on your Attack Speed and weapon lvl" } },
        {"PoisonedKnife", new string[2] { "Poison",             "Your attacks poison the victim for 5 seconds. Poison damage stacks 2/3/4 times"        } },
        {"Claws", new string[2]         { "Bloodlust",          "For each kill you increase damage by 1% up to 20/35/50%"                         } },
        {"Scepter", new string[2]       { "Snowstorm",          "Summons ice blocks toward enemies"                                         } },
        {"Katana", new string[2]        { "Light Pace",         "Passively increases your speed and attack speed for 10/20/30%"                   } }
    };
}
