using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShot : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        DoEnemyCollision(collision);
        Destroy(gameObject);
    }

    protected virtual void DoEnemyCollision(Collision collision)
    {
        
    }
}
