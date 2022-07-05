using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : WeaponAbility
{
    Weapon[] weaponArray = new Weapon[3];
    LineRenderer[] lines = new LineRenderer[3];

    private float laserLength = 20;
    private float standartDelay = 750;

    private LineRenderer laserLine;

    protected override void TurnOnWeaponAbility()
    {
        laserLine = Resources.Load<LineRenderer>("Prefabs/Weapons/Laser/LaserLine");
        InitializeWeapons();
        StartCoroutine(SpawnLasers());
    }

    private void InitializeWeapons()
    {
        weaponArray = FindObjectsOfType<Weapon>();
        for (int i = 0; i < weaponArray.Length; i++)
        {
            weaponArray[i].gameObject.layer = 2;
        }
    }

    private IEnumerator SpawnLasers()
    {
        for (int i = 0; i < weaponArray.Length; i++)
        {
            CastRay(i);
        }
        yield return new WaitForSeconds(DelayToShoot());
        StartCoroutine(SpawnLasers());
    }

    private void CastRay(int rayIndex)
    {
        RaycastHit hit;
        if (Physics.Raycast (LaserRay(rayIndex), out hit, laserLength))
        {
            SpawnLaserLine(rayIndex, hit);
            ApplyDamageToEnemy(hit);
            StartCoroutine(DestroyLaserLine(lines[rayIndex]));
        }
    }

    private void SpawnLaserLine(int i, RaycastHit hit)
    {
        lines[i] = Instantiate(laserLine, player.transform);
        lines[i].SetPosition(0, weaponArray[i].transform.position);
        lines[i].SetPosition(1, hit.point);
    }
    private void ApplyDamageToEnemy(RaycastHit hit)
    {
        if (hit.collider.gameObject.layer == 6)
        {
            if (hit.collider.gameObject.TryGetComponent(out Enemy enemy)) enemy.OnGetDamaged(Mathf.Round(player.damage * 1.7f));
        }
    }

    private IEnumerator DestroyLaserLine(LineRenderer line)
    {
        yield return new WaitForSeconds(1);
        Destroy(line.gameObject);
    }

    private Ray LaserRay(int weaponIndex)
    {
        Vector3 startPosition = weaponArray[weaponIndex].transform.position;
        return new Ray(startPosition, weaponArray[weaponIndex].transform.up);
    }

    private float DelayToShoot()
    {
        return standartDelay / player.attackSpeed / Weapon.currentLevel;
    }
}
