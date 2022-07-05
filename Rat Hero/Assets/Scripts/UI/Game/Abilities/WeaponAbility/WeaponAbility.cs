using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAbility : MonoBehaviour
{
    protected Character player;

    internal void InitializeCurrentWeaponAbility()
    {
        Character currentPlayer = FindObjectOfType<Character>();
        CurrentWeaponAbility(currentPlayer).TurnOnWeaponAbility();
    }

    private WeaponAbility CurrentWeaponAbility(Character player)
    {
        WeaponAbility weaponAbilityObject = WeaponAbilitiesDictionary.weaponAbilityObjectValues.GetValueOrDefault(Weapon.choisedWeapon);
        gameObject.AddComponent(weaponAbilityObject.GetType());
        WeaponAbility currentWeaponAbility = gameObject.GetComponent(weaponAbilityObject.GetType()) as WeaponAbility;
        currentWeaponAbility.player = player;
        return currentWeaponAbility;
    }

    protected virtual void TurnOnWeaponAbility()
    {

    }
}
