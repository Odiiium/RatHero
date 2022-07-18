using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthAbility : Ability
{
    int necromantedEnemiesCount;
    float healModifier = 0.05f;

    internal override void DoAbility()
    {
        if (!onCooldown && ManaBar.mana >= 100 && PauseMenu.isGame)
        {
            ReduceMana(100);
            timeFromCooldown = 0;
            DoNecromancy();
            player.StartCoroutine(DoCoolDown(cooldownTime, abilityView.abilityImageCooldown));
        }
    }

    private void DoNecromancy()
    {
        DamageEnemies();
        if (player != null) HealPlayer(necromantedEnemiesCount);
        necromantedEnemiesCount = 0;
    }

    private void DamageEnemies()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        for (int i = 0; i < enemies.Length; i++)
        {
            if (Vector3.Distance(enemies[i].transform.position, player.transform.position) < 8)
            {
                enemies[i].OnGetDamaged((player.damage + player.Crit()) * 3);
                necromantedEnemiesCount++;
                SpawnParticles(enemies[i]);
            }
        }
    }

    private void HealPlayer(int enemiesCount)
    {
        float healCount = Mathf.Round(HealthBar.maximumHealth * healModifier * enemiesCount);
        HealthBar.healthPoints += healCount;
        Character.onHealthChanged?.Invoke();
    }

    private void SpawnParticles(Enemy enemy)
    {
        var buffParticle = Instantiate(buffParticles(), enemy.transform.position + Vector3.up * 0.25f, enemy.transform.rotation);
        StartCoroutine(DestroyParticles(buffParticle));
    }


    Object buffParticles()
    {
        return Resources.Load("Prefabs/Particles/FourthSkillParticle");
    }

    private IEnumerator DestroyParticles(Object particle)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(particle);
    }

    internal override void SetCooldownTime()
    {
        cooldownTime = 20;
    }

}
