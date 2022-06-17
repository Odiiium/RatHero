using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class 
    RatSwitcherController : MonoBehaviour
{
    [SerializeField] RatSwitcher ratSwitcher;
    [SerializeField] RatSwitcherView ratSwitcherView;

    private void Awake()
    {
        ratSwitcherView.GetButtons();    
    }

    private void Start()
    {
        ratSwitcherView.leftButton.onClick.AddListener(ratSwitcher.SwitchToLeft);
        ratSwitcherView.rightButton.onClick.AddListener(ratSwitcher.SwitchToRight);
        ratSwitcherView.selectButton.onClick.AddListener(ratSwitcher.SelectRat);
    }

    private void OnDisable()
    {
        ratSwitcherView.leftButton.onClick.RemoveAllListeners();
        ratSwitcherView.rightButton.onClick.RemoveAllListeners();
        ratSwitcherView.selectButton.onClick.RemoveAllListeners();

    }





}
