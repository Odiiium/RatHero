using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAbility : Ability
{
    internal override void DoAbility()
    {
        if (!onCooldown && ManaBar.mana >= 50 && PauseMenu.isGame)
        {
            ReduceMana(50);
            timeFromCooldown = 0;
            SpawnClaws();
            StartCoroutine(DoCoolDown(cooldownTime, abilityView.abilityImageCooldown));
        }
    }

    private void SpawnClaws()
    {
        Vector3 spawnPosition = player.transform.position + Vector3.up * 0.2f;
        for (int i = 0; i < 12; i++)
        {
            Instantiate(firstSkillClaws(), spawnPosition, Quaternion.Euler(90, 0, 30 * i));
        }
    }

    Object firstSkillClaws()
    {
        return Resources.Load("Prefabs/UI/FirstSkillAbility/FirstSkillClaws");
    }

    internal override void SetCooldownTime()
    {
        cooldownTime = 10;
    }
}
