using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    private void OnEnable()
    {
        damage = 100;
        name = "Sword";
    }

    private void Update()
    {
        RotateAroundPlayer();
    }

}
