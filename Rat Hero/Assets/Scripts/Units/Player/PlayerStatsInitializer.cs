using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsInitializer : ScriptableObject
{
    static internal float InitializedPlayerDamage()
    {
        float weaponAdditionalDamage = WeaponStats.weaponStatsValues.GetValueOrDefault(Weapon.choisedWeapon)[Weapon.currentLevel - 1] * PlayerStats.Damage / 100;
        float ratAdditionalDamage = RatAdditionalStats.ratStatsValues.GetValueOrDefault(RatSwitcher.rats[RatSwitcher.currentRat])[0] * PlayerStats.Damage / 100;
        return Mathf.Round(PlayerStats.Damage + ratAdditionalDamage + weaponAdditionalDamage);
    }

    static internal float InitializedPlayerDefence()
    {
        float ratAdditionalDefence = RatAdditionalStats.ratStatsValues.GetValueOrDefault(RatSwitcher.rats[RatSwitcher.currentRat])[3] * PlayerStats.Defence / 100;
        return PlayerStats.Defence + ratAdditionalDefence;
    }

    static internal float InitializedPlayerAttackSpeed()
    {
        float ratAdditionalAttackSpeed = RatAdditionalStats.ratStatsValues.GetValueOrDefault(RatSwitcher.rats[RatSwitcher.currentRat])[1] * PlayerStats.AttackSpeed / 100;
        return (PlayerStats.AttackSpeed + ratAdditionalAttackSpeed) / 2;
    }

    static internal float InitializedPlayerSpeed()
    {
        float ratAdditionalSpeed = RatAdditionalStats.ratStatsValues.GetValueOrDefault(RatSwitcher.rats[RatSwitcher.currentRat])[4] * PlayerStats.Speed / 100;
        return PlayerStats.Speed + ratAdditionalSpeed;
    }

    static internal float InitializedPlayerCriticalChance()
    {
        float ratAdditionalCriticalChance = RatAdditionalStats.ratStatsValues.GetValueOrDefault(RatSwitcher.rats[RatSwitcher.currentRat])[5] * PlayerStats.CriticalChance / 100;
        return PlayerStats.CriticalChance + ratAdditionalCriticalChance;
    }
}
