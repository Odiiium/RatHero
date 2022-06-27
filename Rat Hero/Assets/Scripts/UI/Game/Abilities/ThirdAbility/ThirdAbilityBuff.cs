using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdAbilityBuff : MonoBehaviour
{
    Character player;
    void Awake()
    {
        player = FindObjectOfType<Character>();
    }

    void Update()
    {
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        if (player != null)
        {
            transform.position = player.transform.position + Vector3.up * 0.16f;
            transform.rotation = player.transform.rotation * Quaternion.Euler(180, 0, 0);
        }
        else return;
    }
}
