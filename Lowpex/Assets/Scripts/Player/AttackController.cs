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

    private GameObject firstSkill;

    private bool canAttack = true;
    private bool canUseSkill = true;

    public void Init(PlayerData playerData)
    {
        this.playerData = playerData;

        animator = GetComponent<Animator>();
        equipController = GetComponent<EquipController>();

        LoadSkills();
    }

    private void LoadSkills()
    {
        switch (playerData.heroType)
        {
            case HeroType.Mage:
                firstSkill = Resources.Load("Prefabs/Attacks/MageHealSkill") as GameObject;
                break;
            case HeroType.Warrior:
                break;
            case HeroType.Hunter:
                break;
        }
    }

    public void Attack()
    {
        if (!canAttack)
            return;

        StartCoroutine(AttackCoroutine());
        animator.SetTrigger("Attack");
    }

    public void UseFirstSkill()
    {
        if (!canUseSkill || !firstSkill)
            return;

        
        StartCoroutine(SkillTimeout());
    }
    IEnumerator SkillTimeout()
    {
        canUseSkill = false;
        animator.SetTrigger("HealSkill");
        yield return new WaitForSecondsRealtime(0.2f);
        GameObject skill = Instantiate(firstSkill);
        skill.transform.position = this.transform.position;
        skill.transform.SetParent(this.transform);

        yield return new WaitForSecondsRealtime(1.3f);

        canUseSkill = true;
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
