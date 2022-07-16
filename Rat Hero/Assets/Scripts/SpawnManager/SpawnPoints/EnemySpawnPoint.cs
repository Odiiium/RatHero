using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawnPoint : SpawnPoint
{
    [SerializeField] Enemy[] enemies;
    internal UnityAction onEnemyHasBeenKilled;
    internal int enemyCount;

    private void Awake()
    {
        enemyCount = 0;
        spawnCooldown = 15;
        DoStartingSpawn();
    }

    private void OnEnable()
    {
        onEnemyHasBeenKilled += DoSpawn;
    }

    private void OnDisable()
    {
        onEnemyHasBeenKilled -= DoSpawn;
    }

    protected internal override void DoSpawn()
    {
        StartCoroutine(SpawnEnemyWithCooldown());
    }

    private void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, enemies.Length);
        Enemy createdEnemy = Instantiate(enemies[spawnIndex], DistanceForSpawn(), enemies[spawnIndex].transform.rotation);
        createdEnemy.enemySpawnPoint = this;
        enemyCount++;
    }

    private void DoStartingSpawn()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnEnemy();
        }
        DoSpawn();
    }

    private IEnumerator SpawnEnemyWithCooldown()
    {
        yield return new WaitForSeconds(spawnCooldown);
        if (PauseMenu.isGame && enemyCount < 8)
        {
            SpawnEnemy();
            StartCoroutine(SpawnEnemyWithCooldown());
        }
    }

    Vector3 DistanceForSpawn()
    {
        Vector3 randomPoint = Random.insideUnitSphere;
        randomPoint = transform.localPosition + new Vector3(randomPoint.x * 5, 0, randomPoint.z * 5);
        return randomPoint;
    }

}
