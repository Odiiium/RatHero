using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondAbility : Ability
{
    internal override void DoAbility()
    {
        if (!onCooldown && ManaBar.mana >= 50 && PauseMenu.isGame)
        {
            ReduceMana(100);
            timeFromCooldown = 0;
            BuffPlayer();
            player.StartCoroutine(DoCoolDown(cooldownTime, abilityView.abilityImageCooldown));
        }
    }

    private void BuffPlayer()
    {
        SpawnParticles();
        HealPlayer();
        StartCoroutine(SetPlayerStats());
    }

    private IEnumerator SetPlayerStats()
    {
        var currentDefence = player.defence;
        player.defence = 350;
        yield return new WaitForSeconds(2.5f);
        player.defence = currentDefence;
    }

    private void HealPlayer()
    {
        if (HealthBar.healthPoints <= HealthBar.maximumHealth * 0.85f)
        { 
            HealthBar.healthPoints += HealthBar.maximumHealth * 0.15f;
            Character.onHealthChanged?.Invoke();
        }
    }

    private void SpawnParticles()
    {
        var buffParticle = Instantiate(buffParticles(), player.transform.position + Vector3.up * 3.5f, Quaternion.Euler(90,0,0));
        StartCoroutine(DestroyParticles(buffParticle));
    }

    Object buffParticles()
    {
        return Resources.Load("Prefabs/Particles/SecondSkillParticle");
    }

    internal override void SetCooldownTime()
    {
        cooldownTime = 18;
    }

    private IEnumerator DestroyParticles(Object particle)
    {
        yield return new WaitForSeconds(1.4f);
        Destroy(particle);
    }
}
