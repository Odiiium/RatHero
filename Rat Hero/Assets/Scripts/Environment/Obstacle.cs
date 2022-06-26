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
        gameObject.GetComponent<MeshRenderer>().material = Resources.Load<Material>($"Materials/Environment/{pureName()}s/{instanceName()} Transparent");
    }

    private void SetOriginalMaterial()
    {
        gameObject.GetComponent<MeshRenderer>().material = Resources.Load<Material>($"Materials/Environment/{pureName()}s/{instanceName()}");
    }
    string pureName()
    {
        return parentString().Substring(0, parentString().IndexOf(" "));
    }
    string instanceName()
    {
        if (parentString().Contains(")"))
        {     
            return parentString().Substring(0, parentString().IndexOf('(') - 1);
        }
        else return parentString();
    }

    string parentString()
    {
        return gameObject.transform.parent.name;
    }

}
