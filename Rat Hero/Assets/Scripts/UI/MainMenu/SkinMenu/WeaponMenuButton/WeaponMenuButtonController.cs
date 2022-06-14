using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponMenuButtonController : MonoBehaviour
{
    [SerializeField] WeaponMenuButton weaponMenuSwitcher;
    [SerializeField] WeaponMenuButtonView weaponMenuSwitcherView;

    private void Awake()
    {
        weaponMenuSwitcherView.GetButton();
        weaponMenuSwitcherView.goToWeaponMenuButton.onClick.AddListener(weaponMenuSwitcher.GoToWeaponMenu);
    }

}
