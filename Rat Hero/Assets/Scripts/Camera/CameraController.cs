using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] MobileController mobileJoystick;

    static Camera camera;
    Character player;
    private Vector3 cameraPositionRelativeToThePlayer;

    public static float cameraFieldOfView
    {
        get
        {
            if (PlayerPrefs.GetFloat("cameraFieldOfView") != 0) return PlayerPrefs.GetFloat("cameraFieldOfView");
            else return 70;
        }
        set
        {
            if (value <= 100 && value >= 50)
            {
                camera.fieldOfView = value;
                PlayerPrefs.SetFloat("cameraFieldOfView", value);
            }
        }
    }


    private void Start()
    {
        camera = GetComponent<Camera>();
        player = FindObjectOfType<Character>();
        SetFieldOfViewValue();
    }

    private void SetFieldOfViewValue()
    {
        camera.fieldOfView = cameraFieldOfView;
    }
}
