using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RatAdditionalStatsController : MonoBehaviour
{
    [SerializeField] RatAdditionalStats ratAdditionalStats;
    [SerializeField] RatAdditionalStatsView ratAdditionalStatsView;

    public static UnityAction onStatsDisplay;

    private void Awake()
    {
        ratAdditionalStatsView.InitializeStatsUI();
        ratAdditionalStatsView.SetStats();
    }

    private void OnEnable()
    {
        onStatsDisplay += ratAdditionalStatsView.SetStats;
    }

    private void OnDisable()
    {
        onStatsDisplay -= ratAdditionalStatsView.SetStats;
    }
}


