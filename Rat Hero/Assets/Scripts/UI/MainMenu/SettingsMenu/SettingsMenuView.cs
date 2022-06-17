using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuView : MonoBehaviour
{
    internal Scrollbar musicSlider;
    internal Scrollbar soundSlider;
    internal Button backButton;

    internal void InitializeUIElements()
    {
        soundSlider = gameObject.transform.GetChild(1).GetChild(0).GetComponent<Scrollbar>();
        musicSlider = gameObject.transform.GetChild(2).GetChild(0).GetComponent<Scrollbar>();
        backButton = gameObject.transform.GetChild(3).GetComponent<Button>();
    }
}
