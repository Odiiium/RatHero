using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public abstract class AbilityView : MonoBehaviour
{
    internal Button abilityButton;
    internal Button lockedButton;
    internal Image abilityImageCooldown;
    internal TextMeshProUGUI lockedText;

    [SerializeField] protected int requiredLevel;

    internal virtual void InitializeUIElements()
    {
        GameObject childAbilityObject = transform.GetChild(0).gameObject;
        abilityButton = childAbilityObject.transform.GetChild(0).GetComponent<Button>();
        abilityImageCooldown = childAbilityObject.transform.GetChild(1).GetComponent<Image>();
        lockedButton = childAbilityObject.transform.GetChild(2).GetComponent<Button>();
        lockedText = transform.parent.GetChild(0).GetComponent<TextMeshProUGUI>();
        lockedText.gameObject.SetActive(false);
    }

    internal void ShowText()
    {
        StartCoroutine(DoTextLifetime(requiredLevel));
    }

    protected IEnumerator DoTextLifetime(int level)
    {
        lockedText.gameObject.SetActive(true);
        lockedText.text = "This ability will be unlocked at level " + level.ToString();
        yield return new WaitForSeconds(2);
        lockedText.gameObject.SetActive(false);
    }

    internal void SetLockedButtonCondition()
    {
        if (RatLevelUp.CurrentLvl >= requiredLevel) lockedButton.gameObject.SetActive(false);
        else   lockedButton.gameObject.SetActive(true);
    }

}
