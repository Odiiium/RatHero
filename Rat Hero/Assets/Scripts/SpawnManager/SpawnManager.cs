using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Profiling;


public class SpawnManager : MonoBehaviour
{
    [SerializeField] Enemy[] enemies;

    internal static int enemyCount;

    public static UnityAction onEnemyDies;

    Character player;

    private void Awake()
    {
        PauseMenu.isGame = true;
        enemyCount = 0;
        player = FindObjectOfType<Character>();
    }

    private void Start()
    {
        SpawnEnemyWithCooldown();
    }

    void SpawnEnemyWithCooldown()
    {
        Profiler.BeginSample("RandomEnemySpawn");
        InvokeRepeating(nameof(SpawnEnemy), 0, 1);
        Profiler.EndSample();
    }

    private void SpawnEnemy()
    {
        if (PauseMenu.isGame && enemyCount < 30)
        {
            int index = Random.Range(0, enemies.Length);
            Instantiate(enemies[index], DistanceForSpawn(), enemies[index].transform.rotation);
            enemyCount++;
        }
    }

    Vector3 DistanceForSpawn()
    {
        Vector3 randomPoint = Random.insideUnitSphere;
        randomPoint = new Vector3(randomPoint.x, 0, randomPoint.z) * 12 + new  Vector3(2, 0, 2) + player.transform.position;
        return randomPoint;
    }
}
