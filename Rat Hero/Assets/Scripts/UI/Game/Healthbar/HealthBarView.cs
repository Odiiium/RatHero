using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarView : MonoBehaviour
{
    internal Image currentHealth;
    TextMeshProUGUI currentHealthText;

    internal void InitializeUI()
    {
        currentHealth = gameObject.transform.GetChild(0).GetComponent<Image>();
        currentHealthText = gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    internal void SetHealthBarCurrentValue()
    {
        if (currentHealth)
        {
            currentHealth.fillAmount = HealthBar.healthPoints / HealthBar.maximumHealth;
            currentHealthText.text = Mathf.Round(HealthBar.healthPoints) + "";
        }
    }
}
