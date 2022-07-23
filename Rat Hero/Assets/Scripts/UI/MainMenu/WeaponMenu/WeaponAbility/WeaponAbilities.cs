using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAbilities : MonoBehaviour
{
    public static Dictionary<string, string[]> abilityInfoValues = new Dictionary<string, string[]>
    {
        {"Axe", new string[2]           { "Berserker",          "The rat goes berserker and gain additional 10/20/30% damage but lost 10/20/30% health points"        } },
        {"Sword", new string[2]         { "Holy persistance",   "The rat heal himself every 14/12/10 seconds for 3/6/9% from max health" } },
        {"Pistol", new string[2]        { "Shrapnel",           "Sometimes the rat shoots toward enemies. Depends on your attack speed and weapon lvl" } },
        {"PoisonedKnife", new string[2] { "Poison",             "Your attacks poison the victim for 2/4/6 seconds."                                  } },
        {"Claws", new string[2]         { "Bloodlust",          "For each kill you increase damage by 1% up to 20/35/50%"                         } },
        {"Scepter", new string[2]       { "Snowstorm",          "Summons ice blocks toward enemies"                                         } },
        {"Katana", new string[2]        { "Light Pace",         "Passively increases your speed and attack speed for 10/20/30%"                   } },
        {"DruidStaff", new string[2]    { "Nature Wraith",      "Spawns 1/2/3 flower's near player. Flowers damage and slow enemies. Spawn rate depends on your attack speed"                   } },
        {"Bow", new string[2]           { "Arrows Rain",        "Shots 1/2/3 arrows in row. Shot frequency depends on your attack speed."                   } },
        {"ArcaneGun", new string[2]     { "Laser",              "Shots a laser, that shoots through enemies. Shot frequency depends on your attack speed and weapon level." } },
        {"MagicSphere", new string[2]   { "Mana Drain",         "Restore mana for every killed enemy. Restore 2/4/6 % of mana depends on your weapon level" } },
        {"Scythe",      new string[2]   { "Vampirism",          "Restore health for every killed enemy. Restore 1.5/3/4.5 % of health depends on your weapon level." } },
        {"Hammer",      new string[2]   { "Thor's Strike",      "Shakes the earth near your rat and apply damage to every enemy near you. Strike radius and cooldown depends on your weapon level" } },
    };
}
