using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RatLevelUpController : MonoBehaviour
{
    [SerializeField] RatLevelUpView levelUpView;
    [SerializeField] RatLevelUp levelUp;

    UnityAction onLoad;

    private void Awake()
    {
        onLoad += levelUpView.GetPrice;
        onLoad += levelUpView.GetButton;
    }
    private void Start()
    {
        onLoad?.Invoke();
        levelUpView.levelUpButton.onClick.AddListener(PlayerStatsController.onAdd);
    }
}
