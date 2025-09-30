using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    AnimationHandler animationHandler;
    InputHandler inputHandler;
    public string lastAttack;

    private void Awake()
    {
        animationHandler = GetComponentInChildren<AnimationHandler>();
        inputHandler = GetComponent<InputHandler>();
    }

    public void HandleLightAttack(WeaponItem weapon)
    {
        animationHandler.PlayTargetAnimation(weapon.OH_Light_Attack_1, true);
        lastAttack = weapon.OH_Light_Attack_1;


    }

    public void HandleWeaponCombo(WeaponItem weapon)
    {
        if (inputHandler.combo)
        {
            animationHandler.animator.SetBool("canDoCombo", false);

            if (lastAttack == weapon.OH_Light_Attack_1)
            {
                animationHandler.PlayTargetAnimation(weapon.OH_Light_Attack_2, true);
                lastAttack = weapon.OH_Light_Attack_2;
            }
            else if (lastAttack == weapon.OH_Light_Attack_2)
            {
                animationHandler.PlayTargetAnimation(weapon.OH_Light_Attack_3, true);
                lastAttack = weapon.OH_Light_Attack_3;
            }
        }
    }
    
    public void HandleHeavyAttack(WeaponItem weapon)
    {
        animationHandler.PlayTargetAnimation(weapon.OH_Heavy_Attack_1, true);
        lastAttack = weapon.OH_Heavy_Attack_1;
    }
}
