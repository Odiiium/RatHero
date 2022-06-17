using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] Character player;

    private void OnEnable()
    {
        SkinChanger.onChangeSkin += ChangeStats;
    }

    private void OnDisable()
    {
        SkinChanger.onChangeSkin -= ChangeStats;
    }


    void ChangeStats(string skinName)
    {
        return;
    }
}
