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
        InvokeRepeating(nameof(StartManaRegeneration), 1, 1);
    }

    private void OnEnable()
    {
        Character.onManaChanged += manaBarView.SetManaBarCurrentValue;
    }

    private void OnDisable()
    {
        Character.onManaChanged -= manaBarView.SetManaBarCurrentValue;
    }

    private void StartManaRegeneration()
    {
        manaBar.RegenerateMana();
    }
}
