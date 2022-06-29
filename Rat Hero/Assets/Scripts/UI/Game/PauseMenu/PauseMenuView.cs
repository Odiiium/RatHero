using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuView : MonoBehaviour
{
    internal Scrollbar musicScrollbar;
    internal Scrollbar soundScrollbar;
    internal Scrollbar fieldOfViewScrollbar;
    internal Button resumeGameButton;
    internal Button exitButton;

    internal void InitializeUI()
    {
        musicScrollbar = transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Scrollbar>();
        soundScrollbar = transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Scrollbar>();
        fieldOfViewScrollbar = transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<Scrollbar>();
        resumeGameButton = transform.GetChild(2).GetComponent<Button>();
        exitButton = transform.GetChild(3).GetComponent<Button>();
    }



}
