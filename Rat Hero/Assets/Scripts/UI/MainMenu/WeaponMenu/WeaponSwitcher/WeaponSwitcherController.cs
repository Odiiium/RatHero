using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcherController : MonoBehaviour
{
    [SerializeField] WeaponSwitcher weaponSwitcher;
    [SerializeField] WeaponSwitcherView weaponSwitcherView;

    private void Awake()
    {
        weaponSwitcherView.GetButtons();
    }

    private void Start()
    {
        weaponSwitcherView.leftButton.onClick.AddListener(weaponSwitcher.SwitchToLeft);
        weaponSwitcherView.rightButton.onClick.AddListener(weaponSwitcher.SwitchToRight);
        weaponSwitcherView.selectButton.onClick.AddListener(weaponSwitcher.SelectWeapon);
    }
}
