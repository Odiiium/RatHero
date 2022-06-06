using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Unit : MonoBehaviour
{
    protected Slider healthSlider;
    protected Rigidbody rigidBody;

    internal float healthPoints { get; set; }
    internal float damage { get; set; }
    internal float speed { get; set; }

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    protected virtual void  GetDamage()
    {

    }

    protected virtual void Attack()
    {

    }

    protected virtual void Run()
    {

    }

    protected virtual void Run(float x, float z)
    {

    }

}
