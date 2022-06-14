using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RatSwitcherController : MonoBehaviour
{
    [SerializeField] RatSwitcher ratSwitcher;
    [SerializeField] RatSwitcherView ratSwitcherView;

    UnityAction onLoad;
    UnityAction onSwitchingRat;

    private void Awake()
    {
        onLoad += ratSwitcherView.GetButtons;    
    }

    private void Start()
    {
        onLoad?.Invoke();
        ratSwitcherView.leftButton.onClick.AddListener(ratSwitcher.SwitchToLeft);
        ratSwitcherView.rightButton.onClick.AddListener(ratSwitcher.SwitchToRight);
        ratSwitcherView.selectButton.onClick.AddListener(ratSwitcher.SelectRat);
    }





}
