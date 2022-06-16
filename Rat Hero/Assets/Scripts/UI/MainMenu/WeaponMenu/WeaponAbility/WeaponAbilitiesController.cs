using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponAbilitiesController : MonoBehaviour
{
    [SerializeField] WeaponAbilities weaponAbilities;
    [SerializeField] WeaponAbilitiesView weaponAbilitiesView;

    public static UnityAction onWeaponChanged;

    private void Awake()
    {
        weaponAbilitiesView.InitializeUIElements();
        weaponAbilitiesView.ShowWeaponAbilityInfo();
        onWeaponChanged += weaponAbilitiesView.ShowWeaponAbilityInfo;
    }

}
