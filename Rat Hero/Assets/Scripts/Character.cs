using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : Unit
{
    [SerializeField] MobileController mobileJoystick;

    private void OnEnable()
    {
        mobileJoystick.OnMove += Run;
    }

    private void OnDisable()
    {
        mobileJoystick.OnMove -= Run;
    }

    protected override void Run()
    {
        speed = 10;

        Vector3 moveVector = new Vector3(mobileJoystick.xAxis(), 0, mobileJoystick.yAxis());
        rigidBody.AddForce(moveVector *  speed, ForceMode.Force);
    }
}
