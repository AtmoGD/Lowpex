using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EquipController))]
[RequireComponent(typeof(Animator))]
public class GameController : MonoBehaviour
{
    private PlayerData playerData;
    private Animator animator;

    private EquipController equipController;

    void Start()
    {
        equipController = GetComponent<EquipController>();
        equipController.TakePlayer(this.playerData);

        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = Resources.Load("Animations/" + playerData.heroType + "Controller") as RuntimeAnimatorController;
    }

    public void InitPlayer(PlayerData data)
    {
        playerData = data;
    }
    void Update()
    {
        
    }
}
