using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FirstAbilityView : AbilityView
{
    internal override void InitializeUIElements()
    {
        GameObject childAbilityObject = transform.GetChild(0).gameObject;
        abilityButton = childAbilityObject.transform.GetChild(0).GetComponent<Button>();
        abilityImageCooldown = childAbilityObject.transform.GetChild(1).GetComponent<Image>();
    }
}
