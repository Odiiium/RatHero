using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostGameMenuController : MonoBehaviour
{
    [SerializeField] PostGameMenu postGameMenu;
    [SerializeField] PostGameMenuView postGameMenuView;
    [SerializeField] AdsRestartReward adsReward;

    private void Awake()
    {
        postGameMenuView.InitializeUIElements();
        postGameMenu.SetStatsToZero();
        postGameMenuView.HidePostGameMenu();
    }

    private void OnEnable()
    {
        AddListeners();
    }


    private void OnDisable()
    {
        RemoveListeners();
    }

    private void AddListeners()
    {
        postGameMenuView.restartButton.onClick.AddListener(postGameMenu.Restart);
        postGameMenuView.backToMenuButton.onClick.AddListener(postGameMenu.BackToMenu);
        postGameMenuView.adsRestartButton.onClick.AddListener(adsReward.ShowAd);
        PostGameMenu.isDied += postGameMenuView.SetPostGameStatistics;
        PostGameMenu.isDied += postGameMenuView.OpenPostGameMenu;
    }

    private void RemoveListeners()
    {
        postGameMenuView.restartButton.onClick.RemoveListener(postGameMenu.Restart);
        postGameMenuView.backToMenuButton.onClick.RemoveListener(postGameMenu.BackToMenu);
        postGameMenuView.adsRestartButton.onClick.RemoveListener(adsReward.ShowAd);
        PostGameMenu.isDied -= postGameMenuView.SetPostGameStatistics;
        PostGameMenu.isDied -= postGameMenuView.OpenPostGameMenu;
    }

}

