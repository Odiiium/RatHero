using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class PlayerStatsView : MonoBehaviour
{
    List<TextMeshProUGUI> statsCountList = new List<TextMeshProUGUI>(9);
    List<TextMeshProUGUI> addStatCountList = new List<TextMeshProUGUI>(9);

    internal void ShowStats()
    {
        for (int i = 0; i < 7; i++)
        {
            var statCount = gameObject.transform.GetChild(i).transform.GetChild(2).GetComponent<TextMeshProUGUI>();
            var addStatCount = gameObject.transform.GetChild(i).transform.GetChild(3).GetComponent<TextMeshProUGUI>();
            statsCountList.Add(statCount);
            addStatCountList.Add(addStatCount);
        }
        SwitchStatCount();
    }


    private void SwitchStatCount()
    {
        statsCountList[0].text = PlayerStats.Damage + "";
        addStatCountList[0].text = "+" + Mathf.Round(PlayerStats.Damage * 0.04f) + "";
        statsCountList[1].text = PlayerStats.AttackSpeed + "%";
        if (PlayerStats.AttackSpeed < 500) addStatCountList[1].text = "+" + PlayerStats.AttackSpeed * 0.04 + "%"; else addStatCountList[1].text = "+" + 0 + "%";
        statsCountList[2].text = PlayerStats.HealthPoints + "";
        addStatCountList[2].text = "+" + Mathf.Round(PlayerStats.HealthPoints * 0.04f) + "";
        statsCountList[3].text = PlayerStats.Defence + "";
        if (PlayerStats.Defence < 250) addStatCountList[3].text = "+" + 1; else addStatCountList[3].text = "+" + 0;
        statsCountList[4].text = PlayerStats.Speed + "%";
        if (PlayerStats.Speed < 90) addStatCountList[4].text = "+" + PlayerStats.Speed * 0.04 + "%"; else addStatCountList[4].text = "+" + 0 + "%";
        statsCountList[5].text = PlayerStats.CriticalChance + "%";
        if (PlayerStats.CriticalChance < 90) addStatCountList[5].text = "+" + 1 + "%"; else addStatCountList[5].text = "+" + 0 + "%";
        statsCountList[6].text = PlayerStats.Mana + "%";
        if (PlayerStats.Mana < 800) addStatCountList[6].text = "+" + PlayerStats.Mana * 0.04 + "%"; else addStatCountList[6].text = "+" + 0 + "%";
        statsCountList.Clear();
        addStatCountList.Clear();
    }
}
