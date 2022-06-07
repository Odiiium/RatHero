using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon
{
    private void OnEnable()
    {
        damage = 100;
        name = "Axe";
    }

    private void Update()
    {
        RotateAroundPlayer();
    }

}
