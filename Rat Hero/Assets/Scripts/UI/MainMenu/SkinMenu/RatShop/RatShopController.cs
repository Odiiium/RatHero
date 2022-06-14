using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RatShopController : MonoBehaviour
{
    [SerializeField] RatShop ratShop;
    [SerializeField] RatShopView ratShopView;

    static public UnityAction onHide;
    static public UnityAction onShow;


    private void Awake()
    {
        ratShop.StartRatInitialize();
        ratShopView.InitializeUIElements();
        onHide += ratShopView.HideUIElements;
        onShow += ratShopView.ShowUIElements;
        RatShopView.onBuy += ratShop.OnRatBuy;
    }

    private void Start()
    {
        ratShopView.buyButton.onClick.AddListener(RatShopView.onBuy);
    }


}
