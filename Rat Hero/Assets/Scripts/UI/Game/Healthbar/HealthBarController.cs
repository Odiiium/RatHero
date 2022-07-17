using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;
    [SerializeField] HealthBarView healthBarView;

    private void Awake()
    {
        healthBar.SetHealthPoints();
        healthBarView.InitializeUI();
        healthBarView.SetHealthBarCurrentValue();
        InvokeRepeating(nameof(StartHpRegeration), 1, 1);
    }

    private void OnEnable()
    {
        Character.onHealthChanged += healthBarView.SetHealthBarCurrentValue;
    }

    private void OnDisable()
    {
        Character.onHealthChanged -= healthBarView.SetHealthBarCurrentValue;
    }

    private void StartHpRegeration()
    {
        healthBar.RegenerateHp();
    }
}
