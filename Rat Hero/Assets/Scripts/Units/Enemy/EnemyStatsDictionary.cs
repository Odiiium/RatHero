using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsDictionary : MonoBehaviour
{
    public static Dictionary <string, float[]> enemiesStats = new Dictionary<string, float[]>()
    {
        {"Fly",         new float[3]      {600, 35, 1.2f}   },
        {"Mosquito",    new float[3]      {350, 50, 1.4f}   },
        {"Spider",      new float[3]      {600, 40, 0}      },

    };


}
