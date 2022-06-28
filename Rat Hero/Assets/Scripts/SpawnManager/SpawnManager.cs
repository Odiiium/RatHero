using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SpawnManager : MonoBehaviour
{
    [SerializeField] Enemy[] enemies;

    internal static int enemyCount;

    public static UnityAction onSpawningNewEnemy, onEnemyDies;

    Character player;

    private void Awake()
    {
        PauseMenu.isGame = true;
        enemyCount = 0;
        player = FindObjectOfType<Character>();
        onSpawningNewEnemy += SpawnRandomEnemy;
        onEnemyDies += SpawnRandomEnemy;
    }

    private void Start()
    {
        onSpawningNewEnemy?.Invoke();
    }

    private void OnDisable()
    {
        onSpawningNewEnemy -= SpawnRandomEnemy;
        onEnemyDies -= SpawnRandomEnemy;
    }

    void SpawnRandomEnemy()
    {
        if (enemyCount < 50)
        {
            StartCoroutine(SpawnEnemyWithCooldown());
        }
        else return;
    }

    private IEnumerator SpawnEnemyWithCooldown()
    {
        if (PauseMenu.isGame)
        {
            Vector3 spawnPosition = new Vector3(player.transform.position.x + DistanceForSpawn().x, 0, player.transform.position.z + DistanceForSpawn().z);
            int index = Random.Range(0, enemies.Length);
            Instantiate(enemies[index], spawnPosition, enemies[index].transform.rotation);
            enemyCount++;
        }
        yield return new WaitForSeconds(.5f);
        onSpawningNewEnemy();
    }

    Vector3 DistanceForSpawn()
    {
        float randomDistanceX = Random.Range(-15, 15);
        float randomDistanceZ = Random.Range(-15, 15);

        if (Mathf.Abs(randomDistanceX) < 4)
        {
            if (randomDistanceX < 0) randomDistanceX = -5;
            else randomDistanceX = 5;
        }
        if (Mathf.Abs(randomDistanceZ) < 4)
        {
            if (randomDistanceZ < 0) randomDistanceZ = -5;
            else randomDistanceZ = 5;
        }

        return new Vector3(randomDistanceX, 0, randomDistanceZ);
    }
}
