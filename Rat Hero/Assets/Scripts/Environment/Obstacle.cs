using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{ 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerCollider"))
        {
            SetTransparentMaterial();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerCollider"))
        {
            SetOriginalMaterial();
        }
    }

    private void SetTransparentMaterial()
    {
        gameObject.GetComponent<MeshRenderer>().material = Resources.Load<Material>($"Materials/Environment/{pureName()}s/{gameObject.transform.parent.name} Transparent");
    }

    private void SetOriginalMaterial()
    {
        gameObject.GetComponent<MeshRenderer>().material = Resources.Load<Material>($"Materials/Environment/{pureName()}s/{gameObject.transform.parent.name}");
    }

    string pureName()
    {
        return gameObject.transform.parent.name.Substring(0, gameObject.transform.parent.name.IndexOf(" "));
    }

}
