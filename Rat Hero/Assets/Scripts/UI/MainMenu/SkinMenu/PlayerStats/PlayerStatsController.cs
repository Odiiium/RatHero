using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;


public class PlayerStatsController : MonoBehaviour
{
    [SerializeField] PlayerStatsView statsView;
    [SerializeField] PlayerStats stats;

    public static UnityAction onLoad;
    public static UnityAction onAdd;
    public static UnityAction onStatsShowing;

    private void OnEnable()
    {
        SubscribeActions();
        onLoad?.Invoke();
        onStatsShowing?.Invoke();
    }

    private void OnDisable()
    {
        UnsubscribeActions();
    }

    private void SubscribeActions()
    {
        onLoad += stats.LoadStats;
        onAdd += stats.AddStats;
        onAdd += stats.SaveStats;
        onAdd += RatLevelUpView.ShowLevel;
        onStatsShowing += RatLevelUpView.ShowLevel;
        onStatsShowing += statsView.ShowStats;
    }

    private void UnsubscribeActions()
    {
        onLoad -= stats.LoadStats;
        onAdd -= stats.AddStats;
        onAdd -= stats.SaveStats;
        onAdd -= RatLevelUpView.ShowLevel;
        onStatsShowing -= RatLevelUpView.ShowLevel;
        onStatsShowing -= statsView.ShowStats;
    }
}
