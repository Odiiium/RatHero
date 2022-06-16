using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WeaponAbilitiesView : MonoBehaviour
{
    Image abilityImage;
    TextMeshProUGUI abilityDescriptionText;
    TextMeshProUGUI abilityNameText;

    internal void InitializeUIElements()
    {
        abilityNameText = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        abilityDescriptionText = gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        abilityImage = gameObject.transform.GetChild(2).GetComponent<Image>();
    }

    internal void ShowWeaponAbilityInfo()
    {
        WeaponSwitcher weaponSwitcher = FindObjectOfType<WeaponSwitcher>();
        string currentWeaponName = weaponSwitcher.weapons[WeaponSwitcher.currentWeapon];

        abilityNameText.text = WeaponAbilities.abilityInfoValues.GetValueOrDefault(currentWeaponName)[0];
        abilityDescriptionText.text = WeaponAbilities.abilityInfoValues.GetValueOrDefault(currentWeaponName)[1];
        abilityImage.sprite = Resources.Load<Sprite>($"Icons/WeaponAbilities/{currentWeaponName}");



    }
}
