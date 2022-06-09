using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonedKnife : Weapon
{
    private void OnEnable()
    {
        damage = 100;
        name = "PoisonedKnife";
    }

    private void Update()
    {
        RotateAroundPlayer();
    }


}
