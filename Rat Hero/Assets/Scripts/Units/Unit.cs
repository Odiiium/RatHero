using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Unit : MonoBehaviour
{
    protected Rigidbody rigidBody;

    internal virtual float healthPoints
    {
        get { return currentHp; }
        set
        {
            currentHp = value;
            if (currentHp <= 0) Destroy(gameObject);
        }
    }
    internal float currentHp;
    internal float maxHp;
    internal float damage { get; set; }
    internal float speed { get; set; }
    internal float currentSpeed { get; set; }
    protected float rotateSpeed { get; set; }

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    protected virtual void  GetDamage(float damage)
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
