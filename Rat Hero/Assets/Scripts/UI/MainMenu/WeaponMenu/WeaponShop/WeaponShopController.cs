using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class WeaponShopController : MonoBehaviour
{
    [SerializeField] WeaponShop weaponShop;
    [SerializeField] WeaponShopView weaponShopView;

    public static UnityAction onShow;
    public static UnityAction onHide;
    public static UnityAction onShowingCurrentLvl;


    private void Awake()
    {
        weaponShop.StartWeaponInitialize();
        weaponShopView.InitializeUIElements();
        onHide += weaponShopView.HideUIElements;
        onShow += weaponShopView.ShowUIElements;
        WeaponShopView.onBuy += weaponShop.OnWeaponBuy;
    }

    private void Start()
    {
        weaponShopView.buyButton.onClick.AddListener(WeaponShopView.onBuy);
    }

    private void OnDisable()
    {
        onHide -= weaponShopView.HideUIElements;
        onShow -= weaponShopView.ShowUIElements;
        WeaponShopView.onBuy -= weaponShop.OnWeaponBuy;
        weaponShopView.buyButton.onClick.RemoveAllListeners();
    }

}
