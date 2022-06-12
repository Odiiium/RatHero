using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SkinChanger : MonoBehaviour
{
    public static UnityAction<string> onChangeSkin;

    public delegate void OnLoad();
    public static event OnLoad OnLoaded;

    public static SkinChanger instance;

    private void Awake()
    {
        if (instance == null)
        { 
            instance = this;
            onChangeSkin += SkinInitialize;
            OnLoaded?.Invoke();
        }
        else { return; }
    }

    public Dictionary<string, Skin> skinValues = new Dictionary<string, Skin>()
    {
        {"AlbinoRat",       new Albino()            },
        {"DoubleStripeRat", new DoubleStripeRat()   },
        {"RedHatRat",       new RedHatRat()         }
    };

    public void ChangeSkin(string skinName)
    {
        onChangeSkin?.Invoke(skinName);
        Skin.currentSkin = skinValues.GetValueOrDefault(skinName);

    }

    private void SkinInitialize(string skinName)
    {
        gameObject.GetComponent<MeshRenderer>().material = Resources.Load<Material>($"Materials/Units/Characters/{skinName}");
        gameObject.GetComponent<MeshCollider>().sharedMesh = Resources.Load<Mesh>($"Mesh/Units/Characters/{skinName}/{skinName}1");
        gameObject.GetComponent<MeshFilter>().sharedMesh = Resources.Load<Mesh>($"Mesh/Units/Characters/{skinName}/{skinName}1");
        gameObject.GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>($"Animation/Units/Characters/{skinName}");
    }
}
