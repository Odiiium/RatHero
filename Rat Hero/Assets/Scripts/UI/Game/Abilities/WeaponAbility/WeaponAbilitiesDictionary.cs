using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAbilitiesDictionary : MonoBehaviour
{
    internal static Dictionary<string, WeaponAbility> weaponAbilityObjectValues = new Dictionary<string, WeaponAbility>()
    {
        {"Axe",             new Berserker()},
        {"Sword",           new HolyPersistance()},
        {"Pistol",          new Shrapnel()},
        {"PoisonedKnife",   new Poison()} ,
        {"Claws",           new BloodLust()},
        {"Scepter",         new Snowstorm()},
        {"Katana",          new LightPace()},
        {"DruidStaff",      new NatureWraith()},
        {"Bow",             new ArrowsRain()},
        {"ArcaneGun",       new Laser()},
        {"MagicSphere",     new ManaDrain()},
        {"Scythe",          new Vampirism()},
        {"Hammer",          new ThorStrike()}
    };

}
