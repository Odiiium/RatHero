using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : Unit
{
    [SerializeField] MobileController mobileJoystick;

    private void OnEnable()
    {
        speed = 2.2f;
        rotateSpeed = .7f;
    }

    private void Update()
    {
        Run();
    }

    protected override void Run()
    {
        rigidBody.velocity = transform.forward * mobileJoystick.yAxis() * speed;
        transform.Rotate(0, mobileJoystick.xAxis() * rotateSpeed, 0);
    }
}
