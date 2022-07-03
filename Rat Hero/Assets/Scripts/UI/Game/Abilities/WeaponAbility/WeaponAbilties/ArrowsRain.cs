using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsRain : WeaponAbility
{
    float spawnRateModifier = 750;
    protected override void TurnOnWeaponAbility()
    {
        StartCoroutine(SpawnArrows(Weapon.currentLevel));
    }

    private IEnumerator SpawnArrows(int weaponlvl)
    {
        var arrow = Resources.Load("Prefabs/Weapons/Bow/Arrow");
        Weapon[] weaponComponents = player.transform.GetChild(1).GetComponentsInChildren<Weapon>();

        for (int i = 0; i < Weapon.currentLevel; i++)
        {
            SpawnOneArrowWave(weaponComponents, arrow);
            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(SpawnRate(weaponlvl));
        StartCoroutine(SpawnArrows(weaponlvl));
    }

    private void SpawnOneArrowWave(Weapon[] weaponComponents, Object arrow)
    {
        for (int i = 0; i < weaponComponents.Length; i++)
        {
            Quaternion arrowRotation = weaponComponents[i].transform.rotation * Quaternion.Euler(0, 0, 0);
            Instantiate(arrow, weaponComponents[i].transform.position, arrowRotation);
        }
    }

    float SpawnRate(int weaponLvl)
    {
        return spawnRateModifier / weaponLvl / player.attackSpeed;
    }
}
