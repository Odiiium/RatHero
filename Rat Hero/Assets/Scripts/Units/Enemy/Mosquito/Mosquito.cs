using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosquito : Enemy
{
    private void Awake()
    {
        healthPoints = 350;
        damage = 50;
        speed = 1.2f;
        currentSpeed = speed;
    }
}
