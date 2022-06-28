using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostGameMenuController : MonoBehaviour
{
    [SerializeField] PostGameMenu postGameMenu;
    [SerializeField] PostGameMenuView postGameMenuView;

    private void Awake()
    {
        postGameMenuView.InitializeUIElements();
        AddListeners();
        postGameMenu.SetStatsToZero();
        postGameMenuView.HidePostGameMenu();
    }

    private void OnDisable()
    {
        RemoveListeners();
    }

    private void AddListeners()
    {
        postGameMenuView.restartButton.onClick.AddListener(postGameMenu.Restart);
        postGameMenuView.backToMenuButton.onClick.AddListener(postGameMenu.BackToMenu);
        PostGameMenu.isDied += postGameMenuView.SetPostGameStatistics;
        PostGameMenu.isDied += postGameMenuView.OpenPostGameMenu;
    }

    private void RemoveListeners()
    {
        postGameMenuView.restartButton.onClick.RemoveListener(postGameMenu.Restart);
        postGameMenuView.backToMenuButton.onClick.RemoveListener(postGameMenu.BackToMenu);
        PostGameMenu.isDied -= postGameMenuView.SetPostGameStatistics;
        PostGameMenu.isDied -= postGameMenuView.OpenPostGameMenu;
    }

}

