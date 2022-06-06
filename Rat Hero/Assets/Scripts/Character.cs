using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : Unit
{

    public delegate void MoveAction();
    public static event MoveAction OnMove;


    private void OnEnable()
    {
        OnMove += Run;
    }

    private void OnDisable()
    {
        OnMove -= Run;
    }

    protected override void Run(float x, float z)
    {
        Vector3 moveVector = new Vector3(x, 0, z);
        rigidBody.AddForce(moveVector * Time.deltaTime, ForceMode.Force);
    }
}
