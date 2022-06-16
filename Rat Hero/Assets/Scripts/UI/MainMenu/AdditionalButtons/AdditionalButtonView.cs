using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AdditionalButtonView : MonoBehaviour
{
    internal Button settingMenuButton;
    internal Button exitButton;

    internal void GetButton()
    {
        settingMenuButton = gameObject.transform.GetChild(0).GetComponent<Button>();
        exitButton = gameObject.transform.GetChild(1).GetComponent<Button>();
    }
}
