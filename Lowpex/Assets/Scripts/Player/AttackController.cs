using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackController : MonoBehaviour
{
    private PlayerData playerData;

    private Animator animator;
    private EquipController equipController;

    private float hunterAnimationTime = 0.8125f;
    private float mageAnimationTime = 0.625f;
    private float warriorAnimationTime = 0.625f;

    private bool canAttack = true;

    public void Init(PlayerData playerData)
    {
        this.playerData = playerData;

        animator = GetComponent<Animator>();
        equipController = GetComponent<EquipController>();
    }

    public void Attack()
    {
        if (!canAttack)
            return;

        StartCoroutine(AttackCoroutine());
        animator.SetTrigger("Attack");
    }

    IEnumerator AttackCoroutine()
    {
        canAttack = false;

        float attackTime = playerData.GetAttackSpeed();

        animator.SetTrigger("Attack");
        

        float instantiateTime = 1f;

        switch (playerData.heroType)
        {
            case HeroType.Hunter:
                instantiateTime = (hunterAnimationTime / 16) * 12;
                animator.SetFloat("AttackSpeed", attackTime < hunterAnimationTime ? attackTime : 1);
                break;
            case HeroType.Mage:
                instantiateTime = (mageAnimationTime / 16) * 11;
                animator.SetFloat("AttackSpeed", attackTime < mageAnimationTime ? attackTime : 1);
                break;
            case HeroType.Warrior:
                instantiateTime = (warriorAnimationTime / 16) * 5;
                animator.SetFloat("AttackSpeed", attackTime < warriorAnimationTime ? attackTime : 1);
                break;
        }
        
        yield return new WaitForSecondsRealtime(instantiateTime);

        Damage damage = playerData.GetDamage();
        damage.owner = this.gameObject;

        equipController.GetPrimaryWeapon().SendMessage("InstantiateAttack", damage, SendMessageOptions.DontRequireReceiver);

        yield return new WaitForSecondsRealtime(attackTime - instantiateTime);

        canAttack = true;
    }
}
