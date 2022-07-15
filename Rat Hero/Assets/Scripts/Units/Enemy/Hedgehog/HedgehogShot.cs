using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgehogShot : EnemyShot
{
    protected override float SpeedModifier { get => 6.5f;}
    protected override void Awake()
    {
        playerTransform = FindObjectOfType<Skin>().transform;
        GetComponent<Rigidbody>().AddForce(transform.forward * SpeedModifier, ForceMode.Impulse);
        StartCoroutine(StartLifeTime());
    }

    protected override void DoDamageAction(Enemy enemy)
    {
        ChangePlayerHealthPoints(parentEnemy.damage / 2);
    }
}
