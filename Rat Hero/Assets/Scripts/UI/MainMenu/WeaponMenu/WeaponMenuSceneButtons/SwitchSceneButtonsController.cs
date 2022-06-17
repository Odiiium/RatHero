using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSceneButtonsController : MonoBehaviour
{
    [SerializeField] SwitchSceneButtons switchSceneButtons;
    [SerializeField] SwitchSceneButtonsView switchSceneButtonsView;

    private void Awake()
    {
        switchSceneButtonsView.InitializeButtons();
        switchSceneButtonsView.backToSkinMenuButton.onClick.AddListener(switchSceneButtons.GoToSkinMenu);
        switchSceneButtonsView.playButton.onClick.AddListener(switchSceneButtons.PlayGame);
    }
    private void OnDisable()
    {
        switchSceneButtonsView.backToSkinMenuButton.onClick.RemoveAllListeners();
        switchSceneButtonsView.playButton.onClick.RemoveAllListeners();
    }

}
