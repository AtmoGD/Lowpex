using System;
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
    [SerializeField]
    private float saveLoop = 1.5f;
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

        StartCoroutine(SaveCoroutine());
    }

    private void Update()
    {
        if (this.playerData == null)
            return;
    }

    IEnumerator SaveCoroutine()
    {
        while (true)
        {
            StateController.SavePlayer(DataConverter.ConvertFromPlayerData(this.playerData));
            Debug.Log("SavedPlayer: " + this.playerData.position);
            yield return new WaitForSecondsRealtime(saveLoop);
        }
    }
}
