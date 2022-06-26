using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class AbilityView : MonoBehaviour
{
    internal Button abilityButton;
    internal Image lockedImage;
    internal Image abilityImageCooldown;

    internal virtual void InitializeUIElements()
    {
        GameObject childAbilityObject = transform.GetChild(0).gameObject;
        abilityButton = childAbilityObject.transform.GetChild(0).GetComponent<Button>();
        abilityImageCooldown = childAbilityObject.transform.GetChild(1).GetComponent<Image>();
        lockedImage = childAbilityObject.transform.GetChild(2).GetComponent<Image>();
    }
}
