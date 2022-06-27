using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSkillBuff : MonoBehaviour
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
            transform.position = player.transform.position + Vector3.up * 3.5f;
        }
        else return;
    }
}
