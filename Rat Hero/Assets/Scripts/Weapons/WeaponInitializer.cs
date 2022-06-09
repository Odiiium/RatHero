using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInitializer : MonoBehaviour
{
    public static WeaponInitializer instance;

    public delegate void OnLoad();
    public static event OnLoad OnLoaded;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            OnLoaded?.Invoke();
        }
        else { return;}

    }

    public Dictionary<string, Weapon> weaponsValues = new Dictionary<string, Weapon>()
    {
        {"Axe",             new Axe()           },
        {"Pistol",          new Pistol()        },
        {"PoisonedKnife",   new PoisonedKnife() },
        {"Sword",           new Sword()         }
    };
    internal void InitializeWeapon(string weaponName, int weaponLvl)
    {
        if (gameObject.transform.GetChild(0) != null)
        {
            for (int i = 0; i < 3; i++)
            {
                var childObject = gameObject.transform.GetChild(i).gameObject;
                childObject.AddComponent(weaponsValues.GetValueOrDefault(weaponName).GetType());
                childObject.GetComponent<MeshFilter>().mesh = Resources.Load<Mesh>($"Mesh/Weapons/{weaponName}/{weaponName}_lvl{weaponLvl}");
                childObject.GetComponent<MeshRenderer>().material = Resources.Load<Material>($"Materials/Weapons/{weaponName}/{weaponName}_lvl{weaponLvl}");
                childObject.GetComponent<MeshCollider>().sharedMesh = Resources.Load<Mesh>($"Mesh/Weapons/{weaponName}/{weaponName}_lvl{weaponLvl}");
            }
        }
        else return;
    }

}
