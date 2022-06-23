using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAbility : MonoBehaviour
{
    protected Character player;

    internal void InitializeCurrentWeaponAbility()
    {
        Character currentPlayer = FindObjectOfType<Character>();
        WeaponAbility weaponAbilityObject = WeaponAbilitiesDictionary.weaponAbilityObjectValues.GetValueOrDefault(Weapon.choisedWeapon);

        weaponAbilityObject.player = currentPlayer;
        weaponAbilityObject.TurnOnWeaponAbility();
    }

    protected virtual void TurnOnWeaponAbility()
    {
    }
}
