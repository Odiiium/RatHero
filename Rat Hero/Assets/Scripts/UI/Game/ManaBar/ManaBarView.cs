using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ManaBarView : MonoBehaviour
{
    internal Image currentMana;
    TextMeshProUGUI currentManaText;

    internal void InitializeUI()
    {
        currentMana = gameObject.transform.GetChild(1).GetComponent<Image>();
        currentManaText = gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
    }

    internal void SetManaBarCurrentValue()
    {
        currentMana.fillAmount = ManaBar.mana / ManaBar.maximumMana;
        currentManaText.text = Mathf.Round(ManaBar.mana) + "";
    }
}
