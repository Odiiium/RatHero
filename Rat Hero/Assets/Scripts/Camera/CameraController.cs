using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] MobileController mobileJoystick;
    Character player;
    float rotateSpeed = .7f;

    private void Start()
    {
        player = FindObjectOfType<Character>();
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 4.5f, 0);
        transform.Rotate(0, 0, -mobileJoystick.xAxis() * rotateSpeed);
    }
}
