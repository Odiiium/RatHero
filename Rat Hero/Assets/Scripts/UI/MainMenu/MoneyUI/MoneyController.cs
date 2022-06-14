using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoneyController : MonoBehaviour
{
    [SerializeField] Money money;
    [SerializeField] MoneyView moneyView;

    public static UnityAction onMoneyShows;

    private void Awake()
    {
        moneyView.UIInitialize();
        onMoneyShows += moneyView.ShowCurrentMoney;
        onMoneyShows?.Invoke();
    }
}
