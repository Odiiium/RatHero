using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityController : MonoBehaviour
{
    [SerializeField] protected AbilityView abilityView;
    [SerializeField] protected Ability ability;

    private void Awake()
    {
        abilityView.InitializeUIElements();
        abilityView.abilityButton.onClick.AddListener(ability.DoAbility);
    }

    private void OnDisable()
    {
        abilityView.abilityButton.onClick.RemoveListener(ability.DoAbility);
    }

    private void Update()
    {
        if (ability.timeFromCooldown >= -0.1f && ability.timeFromCooldown <= ability.cooldownTime)
        {
            ability.timeFromCooldown += Time.deltaTime;
            abilityView.abilityImageCooldown.fillAmount = 1 - ability.timeFromCooldown / ability.cooldownTime;
            if (ability.timeFromCooldown >= ability.cooldownTime)
            {
                ability.timeFromCooldown = -1;
            }
        }
    }


}


