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

    private void Start()
    {
        onLoad?.Invoke();
        onStatsShowing?.Invoke();
    }
    private void Awake()
    {
        onLoad += stats.LoadStats;
        onAdd += stats.AddStats;
        onAdd += stats.SaveStats;
        onAdd += RatLevelUpView.ShowLevel;
        onStatsShowing += RatLevelUpView.ShowLevel;
        onStatsShowing += statsView.ShowStats;
    }

    private void OnDisable()
    {
        onLoad -= stats.LoadStats;
        onAdd -= stats.AddStats;
        onAdd -= stats.SaveStats;
        onAdd -= RatLevelUpView.ShowLevel;
        onStatsShowing -= RatLevelUpView.ShowLevel;
        onStatsShowing -= statsView.ShowStats;
    }
}
