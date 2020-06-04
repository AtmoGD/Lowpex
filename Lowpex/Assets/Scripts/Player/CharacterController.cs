using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EquipController))]
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AttackController))]
[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(InputController))]
public class CharacterController : MonoBehaviour
{
    private PlayerData playerData;

    private Animator animator;

    private EquipController equipController;
    private MovementController movementController;
    private AttackController attackController;

    public void InitPlayer(PlayerData playerData)
    {
        this.playerData = playerData;

        equipController = GetComponent<EquipController>();
        equipController.Init(playerData);

        attackController = GetComponent<AttackController>();
        attackController.Init(playerData);

        movementController = GetComponent<MovementController>();
        movementController.Init(playerData);

        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = Resources.Load("Animations/" + playerData.heroType + "Controller") as RuntimeAnimatorController;
    }
}
