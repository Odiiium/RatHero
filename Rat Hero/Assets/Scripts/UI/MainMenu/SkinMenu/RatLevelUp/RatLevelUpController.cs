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
        levelUpView.GetPrice();
        levelUpView.GetButton();
    }
    private void Start()
    {
        levelUpView.levelUpButton.onClick.AddListener(PlayerStatsController.onAdd);
        levelUpView.levelUpButton.onClick.AddListener(levelUpView.SetPrice);
    }

    private void OnDisable()
    {
        levelUpView.levelUpButton.onClick.RemoveAllListeners();
    }
}
