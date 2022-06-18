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

        Character.onHealthChanged += healthBarView.SetHealthBarCurrentValue;
    }
}
