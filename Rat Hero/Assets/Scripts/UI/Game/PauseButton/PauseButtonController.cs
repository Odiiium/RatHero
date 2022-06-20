using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonController : MonoBehaviour
{
    [SerializeField] PauseButton pauseButtonModel;
    [SerializeField] PauseButtonView pauseButtonView;

    private void Awake()
    {
        pauseButtonView.InitializePauseButton();
        pauseButtonView.pauseButton.onClick.AddListener(pauseButtonModel.OpenPauseMenu);
    }


}
