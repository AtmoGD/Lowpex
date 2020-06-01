using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EquipController))]
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class CharacterController : MonoBehaviour
{
    private PlayerData playerData;

    private EquipController equipController;
    private Animator animator;

    public void InitPlayer(PlayerData playerData)
    {
        this.playerData = playerData;

        equipController = GetComponent<EquipController>();
        equipController.TakePlayer(playerData);

        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = Resources.Load("Animations/" + playerData.heroType + "Controller") as RuntimeAnimatorController;
    }
}
