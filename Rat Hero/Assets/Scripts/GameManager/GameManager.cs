using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int frameRate = 120;

    private void Awake()
    {
        Application.targetFrameRate = frameRate;
    }

}
