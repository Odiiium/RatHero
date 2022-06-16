using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SwitchSceneButtonsView : MonoBehaviour
{
    internal Button playButton;
    internal Button backToSkinMenuButton;

    internal void InitializeButtons()
    {
        backToSkinMenuButton = gameObject.transform.GetChild(1).GetComponent<Button>();
        playButton = gameObject.transform.GetChild(2).GetComponent<Button>();
    }
}
