using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FpsCount : MonoBehaviour
{
    TextMeshProUGUI fpsText;
    public int FPS { get; set; }

    float timeSinceFpsShow;

    private void Start()
    {
        fpsText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        timeSinceFpsShow += Time.deltaTime;
        if (timeSinceFpsShow > 0.5f)
        {
            ShowFps();
        }
    }

    private void ShowFps()
    {
        FPS = (int)(1 / Time.unscaledDeltaTime);
        fpsText.text = FPS.ToString();
        timeSinceFpsShow = 0;
    }
}
