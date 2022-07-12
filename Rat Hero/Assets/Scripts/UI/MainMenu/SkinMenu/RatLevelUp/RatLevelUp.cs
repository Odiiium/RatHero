using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatLevelUp : MonoBehaviour
{
    public static int CurrentLvl { get { return PlayerPrefs.GetInt("currentLvl"); } set { PlayerPrefs.SetInt("currentLvl", value); } }

}
