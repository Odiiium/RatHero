using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponStatsController : MonoBehaviour
{
    [SerializeField] WeaponStats weaponStats;
    [SerializeField] WeaponStatsView weaponStatsView;

    public static UnityAction onStatsDisplay;

    private void Awake()
    {
        weaponStatsView.InitializeStatsUI();
        weaponStatsView.SetStats();
    }

    private void OnEnable()
    {
        onStatsDisplay += weaponStatsView.SetStats;
    }

    private void OnDisable()
    {
        onStatsDisplay -= weaponStatsView.SetStats;
    }
}
