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
        transform.position = player.transform.position;

        transform.rotation = player.transform.rotation * Quaternion.Euler(-90, 0, 180);

    }

}
