using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPoint : MonoBehaviour
{
    protected float spawnCooldown;
    protected internal abstract void DoSpawn();


}
