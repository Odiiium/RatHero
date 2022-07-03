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
    }
    private void OnEnable()
    {
        weaponMenuSwitcherView.goToWeaponMenuButton.onClick.AddListener(weaponMenuSwitcher.GoToWeaponMenu);
    }

    private void OnDisable()
    {
        weaponMenuSwitcherView.goToWeaponMenuButton.onClick.RemoveAllListeners();
    }

}
