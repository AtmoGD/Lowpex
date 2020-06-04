using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject heroPrefab;
    public FixedJoystick movementJoystick;
    public FixedJoystick attackJoystick;

    private PlayerData playerData;
    private Camera mainCamera;
    private void Start()
    {
        this.playerData = StateController.LoadActualPlayer();
        InitHero(playerData);
    }
    private void InitHero(PlayerData playerData)
    {
        GameObject hero = Instantiate(heroPrefab);
        heroPrefab.transform.position = playerData.position;

        mainCamera = Camera.main;
        mainCamera.SendMessage("FollowTarget", hero);

        hero.AddComponent<CharacterController>();
        hero.SendMessage("InitPlayer", playerData);

        InputController inputController =  hero.GetComponent<InputController>();
        inputController.SendMessage("TakeTarget", hero);
        inputController.SendMessage("TakeCamera", mainCamera.gameObject);
        inputController.SendMessage("TakeMovementJoystick", movementJoystick);
        inputController.SendMessage("TakeAttackJoystick", attackJoystick);
    }
}
