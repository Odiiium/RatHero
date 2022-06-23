using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WeaponAbilityView : MonoBehaviour
{
    internal Image weaponAbilityImage;
    internal TextMeshProUGUI weaponAbilityText;

    internal void InitializeWeaponAbilityUI()
    {
        weaponAbilityImage = transform.GetChild(0).GetComponent<Image>();
        weaponAbilityText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        SetWeaponAbilityInfo();
    }

    private void SetWeaponAbilityInfo()
    {
        string currentWeaponName = Weapon.choisedWeapon;
        weaponAbilityImage.sprite = Resources.Load<Sprite>($"Icons/WeaponAbilities/{currentWeaponName}");
        weaponAbilityText.text = WeaponAbilities.abilityInfoValues.GetValueOrDefault(currentWeaponName)[0];
    }
}
