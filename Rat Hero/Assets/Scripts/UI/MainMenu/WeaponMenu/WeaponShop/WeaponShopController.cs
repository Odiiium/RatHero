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
        weaponShopView.HideUIElements();
    }

    private void OnEnable()
    {
        SubscribeActions();
    }

    private void OnDisable()
    {
        UnsubscribeActions();
    }

    private void SubscribeActions()
    {
        onHide += weaponShopView.HideUIElements;
        onShow += weaponShopView.ShowUIElements;
        WeaponShopView.onBuy += weaponShop.OnWeaponBuy;
        weaponShopView.buyButton.onClick.AddListener(WeaponShopView.onBuy);
    }

    private void UnsubscribeActions()
    {
        onHide -= weaponShopView.HideUIElements;
        onShow -= weaponShopView.ShowUIElements;
        WeaponShopView.onBuy -= weaponShop.OnWeaponBuy;
        weaponShopView.buyButton.onClick.RemoveAllListeners();
    }
}
