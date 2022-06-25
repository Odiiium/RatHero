using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrapnel : WeaponAbility
{
    float spawnRateModifier = 750;
    protected override void TurnOnWeaponAbility()
    {
        StartCoroutine(SpawnBullets(Weapon.currentLevel));
    }

    private IEnumerator SpawnBullets(int weaponlvl)
    {
        var bullet = Resources.Load("Prefabs/Weapons/Pistol/Bullet");
        Weapon[] weaponComponents = player.transform.GetChild(1).GetComponentsInChildren<Weapon>();

        for (int i = 0; i < weaponComponents.Length; i++)
        {
            Quaternion bulletRotation = weaponComponents[i].transform.rotation * Quaternion.Euler(-90, 0, 0);
            Instantiate(bullet, weaponComponents[i].transform.position, bulletRotation);
        }

        yield return new WaitForSeconds(SpawnRate(weaponlvl));
        StartCoroutine(SpawnBullets(weaponlvl));
    }

    float SpawnRate(int weaponLvl)
    {
        return spawnRateModifier / weaponLvl / player.attackSpeed;
    }
}
