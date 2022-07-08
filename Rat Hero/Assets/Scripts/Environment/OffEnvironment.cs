using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OffEnvironment : MonoBehaviour
{

    [SerializeField] Button switchEnvironmentButton;
    [SerializeField] GameObject environmentObject;

    bool switchCondition;

    public void SwitchEnvironmentCondition()
    {
        environmentObject.SetActive(switchCondition);
        switchCondition = !switchCondition;
    }
}
