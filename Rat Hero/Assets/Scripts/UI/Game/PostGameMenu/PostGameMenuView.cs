using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PostGameMenuView : MonoBehaviour
{ 
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject postGameMenu;

    internal TextMeshProUGUI cheeseEarnedText;
    internal TextMeshProUGUI enemiesKilledText;
    internal TextMeshProUGUI timeAlivedText;

    internal Button restartButton;
    internal Button backToMenuButton;

    internal void InitializeUIElements()
    {
        InitializeTextElements();
        InitializeButtonElements();
    }   

    private void InitializeButtonElements()
    {
        restartButton = transform.GetChild(0).GetChild(4).GetChild(1).GetComponent<Button>();
        backToMenuButton = transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<Button>();
    }

    private void InitializeTextElements()
    {
        cheeseEarnedText = transform.GetChild(0).GetChild(1).GetChild(2).GetComponent<TextMeshProUGUI>();
        enemiesKilledText = transform.GetChild(0).GetChild(2).GetChild(2).GetComponent<TextMeshProUGUI>();
        timeAlivedText = transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    internal void SetPostGameStatistics()
    {
        cheeseEarnedText.text = PostGameMenu.cheeseGained.ToString();
        enemiesKilledText.text = PostGameMenu.killedEnemies.ToString();
        if (PostGameMenu.timeAlivedInMinutes()[1] >= 10)
        {
            timeAlivedText.text = "Alived time\n" + PostGameMenu.timeAlivedInMinutes()[0] + ":" + PostGameMenu.timeAlivedInMinutes()[1];
        }
        else timeAlivedText.text = "Alived time\n" + PostGameMenu.timeAlivedInMinutes()[0] + ":0" + PostGameMenu.timeAlivedInMinutes()[1];
    }

    internal void HidePostGameMenu()
    {
        postGameMenu.SetActive(false);
    }

    internal void OpenPostGameMenu()
    {
        gameUI.SetActive(false);
        postGameMenu.SetActive(true);
    }
    
}
