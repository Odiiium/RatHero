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
        }
        else { return; }
    }

    private void OnDisable()
    {
        onChangeSkin -= SkinInitialize;
    }

    private void Start()
    {
        OnLoaded?.Invoke();
    }
    public void ChangeSkin(string skinName)
    {
        onChangeSkin?.Invoke(skinName);
        DisplayRat(skinName);
    }

    private void SkinInitialize(string skinName)
    {
        gameObject.GetComponent<MeshRenderer>().material = Resources.Load<Material>($"Materials/Units/Characters/{skinName}");
        gameObject.GetComponent<MeshFilter>().sharedMesh = Resources.Load<Mesh>($"Mesh/Units/Characters/{skinName}/{skinName}1");
        if (gameObject.name == "MenuSkin") return;
        else
        {
            gameObject.GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>($"Animation/Units/Characters/{skinName}/{skinName}");
        }
    }
    private void DisplayRat(string skinName)
    {
        if (PlayerPrefs.GetInt(skinName) == 1) RatShopController.onHide?.Invoke();
        else RatShopController.onShow?.Invoke();

    }
}
