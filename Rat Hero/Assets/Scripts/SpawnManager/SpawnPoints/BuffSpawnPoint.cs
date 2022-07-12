using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawnPoint : SpawnPoint
{
    [SerializeField] Buff[] buffs;

    private void Awake()
    {
        spawnCooldown = 5;
        SpawnBuff();
    }

    protected internal override void DoSpawn()
    {
        StartCoroutine(DoSpawnCooldown());
    }

    private void SpawnBuff()
    {
        Buff createdBuff = Instantiate(randomBuff(), transform.position, transform.rotation);
        createdBuff.buffSpawnPoint = this;
    }

    private IEnumerator DoSpawnCooldown()
    {
        yield return new WaitForSeconds(spawnCooldown);
        SpawnBuff();
    }

    Buff randomBuff()
    {
        return buffs[Random.Range(0, buffs.Length)];
    }
}
