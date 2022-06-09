using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInitializer : MonoBehaviour
{
    public static WeaponInitializer instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else { return;}

    }

    static Dictionary<string, Weapon> weaponsValues = new Dictionary<string, Weapon>()
    {
        {"Axe",             new Axe()           },
        {"Pistol",          new Pistol()        },
        {"PoisonedKnife",   new PoisonedKnife() },
        {"Sword",           new Sword()         }
    };

    internal void InitialWeapon(string weaponName, int weaponLvl)
    {
        gameObject.AddComponent(weaponsValues.GetValueOrDefault(weaponName).GetType());
        gameObject.GetComponent<MeshFilter>().mesh = Resources.Load<Mesh>($"Mesh/Weapons/{weaponName}/{weaponName}_lvl{weaponLvl}");
        gameObject.GetComponent<MeshRenderer>().material = Resources.Load<Material>($"Materials/Weapons/{weaponName}/{weaponName}_lvl{weaponLvl}");
        gameObject.GetComponent<MeshCollider>().sharedMesh = Resources.Load<Mesh>($"Mesh/Weapons/{weaponName}/{weaponName}_lvl{weaponLvl}");
    }



}
