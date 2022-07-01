using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffParticle : MonoBehaviour
{
    Skin player;
 
    private void Start()
    {
        player = FindObjectOfType<Skin>();
    }

    private void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 0.1f, 0);
        transform.rotation = player.transform.rotation * Quaternion.Euler(90, 0, 0);
    }

}
