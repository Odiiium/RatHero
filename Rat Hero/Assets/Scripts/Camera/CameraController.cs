using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] MobileController mobileJoystick;

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
            if (value <= 100 && value >= 50) PlayerPrefs.SetFloat("cameraFieldOfView", value);
        }
    }


    private void Start()
    {
        player = FindObjectOfType<Character>();
        cameraPositionRelativeToThePlayer = player.transform.InverseTransformPoint(transform.position);
    }

    private void Update()
    {
        transform.position = player.transform.TransformPoint(cameraPositionRelativeToThePlayer);
        transform.LookAt(player.transform.position + new Vector3(0, .85f, 0));
    }
}
