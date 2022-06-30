using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffUIController : MonoBehaviour
{
    [SerializeField] BuffUI buffUI;
    [SerializeField] BuffUIView buffUIView;

    private void Awake()
    {
        buffUIView.InitializeUIElements();
        BuffUI.currentBuffCount = 0;
        Buff.onGetBuff += buffUI.HideBuffUI;
    }

    private void OnDisable()
    {
        Buff.onGetBuff -= buffUI.HideBuffUI;
    }

}
