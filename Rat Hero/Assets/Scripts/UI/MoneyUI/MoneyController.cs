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
        if (gameObject.name != "MoneyGameUI")
        {
            moneyView.UIInitialize();
            onMoneyShows += moneyView.ShowCurrentMoney;
            onMoneyShows?.Invoke();
        }
        else
        {
            moneyView.GameUIInitialize();
            moneyView.ShowCurrentMoneyInGame();
            Money.onCheeseAdding += moneyView.ShowCurrentMoneyInGame;
        }
    }

    private void OnDisable()
    {
        if (gameObject.name != "MoneyGameUI")
        {
            onMoneyShows -= moneyView.ShowCurrentMoney;
        }
        else
        { 
            Money.onCheeseAdding -= moneyView.ShowCurrentMoneyInGame;
        }
    }
}
