using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBarController : MonoBehaviour
{
    [SerializeField] ManaBar manaBar;
    [SerializeField] ManaBarView manaBarView;

    private void Awake()
    {
        manaBar.SetManaPoints();
        manaBarView.InitializeUI();
        manaBarView.SetManaBarCurrentValue();

        Character.onManaChanged += manaBarView.SetManaBarCurrentValue;
    }

    private void OnDisable()
    {
        Character.onManaChanged -= manaBarView.SetManaBarCurrentValue;
    }
}
