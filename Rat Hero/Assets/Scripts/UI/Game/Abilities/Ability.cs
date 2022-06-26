using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ability : MonoBehaviour
{
    [SerializeField] protected FirstAbilityView firstAbilityView;

    protected Character player;

    internal bool onCooldown;

    internal float timeFromCooldown;
    internal float cooldownTime;

    private void Awake()
    {
        player = FindObjectOfType<Character>();
        onCooldown = false;
        SetCooldownTime();
    }
    internal virtual void DoAbility()
    {
    }

    internal virtual void SetCooldownTime()
    {
    }

    internal void ReduceMana(float mana)
    {
        ManaBar.mana -= mana;
        Character.onManaChanged?.Invoke();
    }

    internal IEnumerator DoCoolDown(float cooldownTime, Image lockedImage)
    {
        onCooldown = true;
        lockedImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(cooldownTime);
        lockedImage.gameObject.SetActive(false);
        onCooldown = false;
    }


}
