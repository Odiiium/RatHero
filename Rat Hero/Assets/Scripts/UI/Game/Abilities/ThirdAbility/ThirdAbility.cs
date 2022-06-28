using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdAbility : Ability
{
    int jumpModifier = 300;

    internal override void DoAbility()
    {
        if (!onCooldown && ManaBar.mana >= 35 && PauseMenu.isGame)
        {
            ReduceMana(35);
            timeFromCooldown = 0;
            DoJump();
            BuffPlayer();
            StartCoroutine(DoCoolDown(cooldownTime, abilityView.abilityImageCooldown));
        }
    }

    private void BuffPlayer()
    {
        SpawnParticles();
        StartCoroutine(SetPlayerStats());
    }

    private IEnumerator SetPlayerStats()
    {
        var currentAttackSpeed = player.attackSpeed;
        var currentSpeed = player.speed;
        player.attackSpeed *= 1.5f;
        player.speed *= 1.2f;
        yield return new WaitForSeconds(3);
        player.attackSpeed = currentAttackSpeed;
        player.speed = currentSpeed;
    }

    private void DoJump()
    {
        player.GetComponent<Rigidbody>().AddRelativeForce(0, jumpModifier, jumpModifier + 100, ForceMode.Impulse);
        Character.isGrounded = false;
    }

    private void SpawnParticles()
    {
        var buffParticle = Instantiate(buffParticles(), player.transform.position + Vector3.up * 0.16f, Quaternion.Euler(180, 0, 0));
        StartCoroutine(DestroyParticles(buffParticle));
    }

    Object buffParticles()
    {
        return Resources.Load("Prefabs/Particles/ThirdSkillParticle");
    }

    private IEnumerator DestroyParticles(Object particle)
    {
        yield return new WaitForSeconds(3);
        Destroy(particle);
    }

    internal override void SetCooldownTime()
    {
        cooldownTime = 5;
    }

}
