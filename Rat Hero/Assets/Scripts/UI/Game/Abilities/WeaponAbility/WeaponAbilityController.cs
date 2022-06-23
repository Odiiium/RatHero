using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAbilityController : MonoBehaviour
{
    [SerializeField] WeaponAbility weaponAbility;
    [SerializeField] WeaponAbilityView weaponAbilityView;

    private void Awake()
    {
        weaponAbilityView.InitializeWeaponAbilityUI();
    }

    private void Start()
    {
        weaponAbility.InitializeCurrentWeaponAbility();
    }
}
