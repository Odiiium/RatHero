using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponMenuButtonView : MonoBehaviour
{
    internal Button goToWeaponMenuButton;


    internal void GetButton()
    {
        goToWeaponMenuButton = gameObject.GetComponent<Button>();
    }
}
