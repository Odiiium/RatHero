using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RatLevelUpController : MonoBehaviour
{
    [SerializeField] RatLevelUpView levelUpView;
    [SerializeField] RatLevelUp levelUp;

    private void Awake()
    {
        levelUpView.GetButton();
        levelUpView.GetPrice();
        RatLevelUpView.ShowLevel();
    }

    private void OnEnable()
    {
        AddListenersToButton();
    }

    private void OnDisable()
    {
        levelUpView.levelUpButton.onClick.RemoveAllListeners();
    }

    private void AddListenersToButton()
    {
        levelUpView.levelUpButton.onClick.AddListener(PlayerStatsController.InvokeOnAddAction);
        levelUpView.levelUpButton.onClick.AddListener(levelUpView.SetPrice);
        levelUpView.levelUpButton.onClick.AddListener(MoneyController.InvokeOnMoneyShowsAction);
    }

}
