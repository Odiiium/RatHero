using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureWraith : WeaponAbility
{

    float spawnRateModifier = 3000;

    protected override void TurnOnWeaponAbility()
    {
        StartCoroutine(SpawnFlowers());
    }

    private IEnumerator SpawnFlowers()
    {
        for (int i = 0; i < Weapon.currentLevel; i++)
        {
            DruidFlower druidFlower= Instantiate(DruidFlower(), RandomSpawnPosition(), player.transform.rotation);
            druidFlower.player = player;
        }
        yield return new WaitForSeconds(SpawnRate());
        StartCoroutine(SpawnFlowers());
    }

    private DruidFlower DruidFlower()
    {
        return Resources.Load<DruidFlower>("Prefabs/Weapons/DruidStaff/DruidFlower");
    }

    private Vector2 randomPosition()
    {
        return Random.insideUnitCircle * 5;
    }

    private Vector3 RandomSpawnPosition()
    {
        Vector3 playerPosition = player.transform.position;
        return new Vector3(playerPosition.x + randomPosition().x, playerPosition.y - 0.22f, playerPosition.z + randomPosition().y);
    }

    private float SpawnRate()
    {
        return spawnRateModifier / Weapon.currentLevel / player.attackSpeed;
    }   
}
