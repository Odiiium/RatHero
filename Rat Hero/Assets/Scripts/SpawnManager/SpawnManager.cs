using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Profiling;


public class SpawnManager : MonoBehaviour
{
    public static UnityAction onEnemyDies;

    private void Awake()
    {
        PauseMenu.isGame = true;
    }


}
