using UnityEngine;
using UnityEngine.Events;


public class PlayerStatsController : MonoBehaviour
{
    [SerializeField] PlayerStatsView statsView;
    [SerializeField] PlayerStats stats;

    internal static UnityAction onLoad;
    internal static UnityAction onAdd;
    internal static UnityAction onStatsShowing;

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

    internal static void InvokeOnAddAction()
    {
        onAdd?.Invoke();
    }
}
