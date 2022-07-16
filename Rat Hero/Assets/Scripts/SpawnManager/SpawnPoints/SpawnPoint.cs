using UnityEngine;

public abstract class SpawnPoint : MonoBehaviour
{
    protected float spawnCooldown;
    protected internal abstract void DoSpawn();


}
