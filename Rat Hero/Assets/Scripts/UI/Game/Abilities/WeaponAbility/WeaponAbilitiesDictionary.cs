using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAbilitiesDictionary : MonoBehaviour
{
    Berserker bers = new Berserker();

    internal static Dictionary<string, WeaponAbility> weaponAbilityObjectValues = new Dictionary<string, WeaponAbility>()
    {
        {"Axe",             new Berserker()},
        {"Sword",           new HolyPersistance()},
        {"Pistol",          new Shrapnel()},
        {"PoisonedKnife",   new Poison()} ,
        {"Claws",           new BloodLust()},
        {"Scepter",         new Snowstorm()},
        {"Katana",          new LightPace()}
    };

}
