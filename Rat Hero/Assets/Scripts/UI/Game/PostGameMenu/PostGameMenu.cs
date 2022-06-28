using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PostGameMenu : MonoBehaviour
{
    internal static UnityAction isDied;

    internal static int killedEnemies, cheeseGained;

    internal static float timeAlived;

    internal static int[] timeAlivedInMinutes()
    {
        int minutesTime = (int)timeAlived / 60;
        int secondsTime = (int)timeAlived % 60;

        return new int[2] { minutesTime, secondsTime };
    }

    internal void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    internal void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    internal void SetStatsToZero()
    {
        killedEnemies = 0;
        cheeseGained = 0;
        timeAlived = 0;
    }

}
