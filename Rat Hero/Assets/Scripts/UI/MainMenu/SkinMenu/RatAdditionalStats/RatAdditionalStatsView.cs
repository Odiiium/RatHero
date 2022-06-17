using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RatAdditionalStatsView : MonoBehaviour
{
    TextMeshProUGUI[] ratStatsText = new TextMeshProUGUI[7];
    GameObject[] ratStatComponent = new GameObject[7];

    internal void InitializeStatsUI()
    {
        for (int i = 0; i < 7; i++)
        {
            ratStatComponent[i] = gameObject.transform.GetChild(i).gameObject;
            ratStatsText[i] = gameObject.transform.GetChild(i).GetChild(2).GetComponent<TextMeshProUGUI>();
        }
    }

    internal void SetStats()
    {
        float[] ratStatsArray = RatAdditionalStats.ratStatsValues.GetValueOrDefault(RatSwitcher.rats[RatSwitcher.currentRat]);

        for (int i = 0; i < 7; i++)
        {
            if (ratStatsArray[i] != 0)                              // Checking is if choisedRat has "0" in their stats. If has then don't show stats in UI.
            {
                ratStatComponent[i].gameObject.SetActive(true);
                ratStatsText[i].text = "+" + ratStatsArray[i] + "%";             
            }                                            
            else
            {
                ratStatComponent[i].gameObject.SetActive(false);
            }
        }
    }

}
