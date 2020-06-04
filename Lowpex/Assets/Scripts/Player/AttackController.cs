using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackController : MonoBehaviour
{
    private PlayerData playerData;

    private Animator animator;
    private EquipController equipController;

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
        animator.SetFloat("AttackSpeed", 1 / attackTime);

        float instantiateTime = playerData.heroType == HeroType.Hunter ? (attackTime / 8) * 6 : playerData.heroType == HeroType.Mage ? (attackTime / 8) * 7 : attackTime; 
        yield return new WaitForSecondsRealtime(instantiateTime);

        Damage damage = playerData.GetDamage();
        damage.owner = this.gameObject;

        equipController.GetPrimaryWeapon().SendMessage("InstantiateAttack", damage, SendMessageOptions.DontRequireReceiver);

        yield return new WaitForSecondsRealtime(attackTime - instantiateTime);

        canAttack = true;
    }
}
