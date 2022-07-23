using System.Collections;
using UnityEngine;

public class ManaDrain : WeaponAbility
{
    private float manaDrainModifier = 0.02f;

    private void OnEnable()
    {
        TurnOnWeaponAbility();
    }

    private void OnDisable()
    {
        SpawnManager.onEnemyDies -= RestoreMana;
    }

    protected override void TurnOnWeaponAbility()
    {
        SpawnManager.onEnemyDies += RestoreMana;
    }

    private void RestoreMana()
    {
        int manaToHeal = (int)(ManaBar.maximumMana * manaDrainModifier * Weapon.currentLevel);
        if (ManaBar.mana <= ManaBar.maximumMana - manaToHeal)
        {
            ManaBar.mana += manaToHeal;
            Character.onManaChanged?.Invoke();
        }
        else ManaBar.mana = ManaBar.maximumMana;
    }

}
