using System.Collections;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour
{
    internal Transform followedObjectTransform;
    bool isPlayer;

    private void Start()
    {
        if (followedObjectTransform.gameObject.GetComponent<Character>()) isPlayer = true;
    }

    void Update()
    {
        FollowToUnit();
    }

    private void FollowToUnit()
    {
        if (isPlayer)
        {
            transform.position = followedObjectTransform.position + followedObjectTransform.transform.forward * .3f + Vector3.up * .1f;
        }
        else transform.position = followedObjectTransform.position;
    }
}