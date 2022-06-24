using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : WeaponAbility
{
    float spawnRateModifier = 1500;
    protected override void TurnOnWeaponAbility()
    {
        StartCoroutine(SpawnIceBlocks(Weapon.currentLevel));
    }

    private IEnumerator SpawnIceBlocks(int weaponlvl)
    {
        var iceBlock = Resources.Load("Prefabs/Weapons/Scepter/IceBlock");
        Weapon[] weaponComponents = player.transform.GetChild(1).GetComponentsInChildren<Weapon>();

        for (int i = 0; i < weaponComponents.Length; i++)
        {
            Instantiate(iceBlock, weaponComponents[i].transform.position, weaponComponents[i].transform.rotation);
        }

        yield return new WaitForSeconds(SpawnRate(weaponlvl));
        StartCoroutine(SpawnIceBlocks(weaponlvl));
    }

    float SpawnRate(int weaponLvl)
    {
        return 1500 / weaponLvl / player.attackSpeed;
    }
}
