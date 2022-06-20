using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseButtonView : MonoBehaviour
{
    internal Button pauseButton;

    internal void InitializePauseButton()
    {
        pauseButton = GetComponent<Button>();
    }

}
