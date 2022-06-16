using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class WeaponLevelUpController : MonoBehaviour
{
    [SerializeField] WeaponLevelUp weaponLevelUp;
    [SerializeField] WeaponLevelUpView weaponLevelUpView;

    public static UnityAction onWeaponChanging;

    private void Awake()
    {
        weaponLevelUpView.GetButton();
    }

    void Start()
    {
        weaponLevelUpView.GetPrice();
        onWeaponChanging += weaponLevelUpView.SetPrice;
        weaponLevelUpView.levelUpButton.onClick.AddListener(weaponLevelUp.WeaponLevelingUp);
    }
}
