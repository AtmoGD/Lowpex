using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject heroPrefab;
    public FixedJoystick movementJoystick;
    public FixedJoystick attackJoystick;
    public GameObject heroPortraitBackground;

    private PlayerData playerData;
    private Camera mainCamera;
    private void Start()
    {
        this.playerData = StateController.LoadActualPlayer();
        InitHero(playerData);
        InitHeroPortrait(playerData);
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
    private void InitHeroPortrait(PlayerData playerData)
    {
        GameObject heroPortrait = Instantiate(heroPrefab);
        heroPortrait.AddComponent<EquipController>();
        heroPortrait.SendMessage("Init", playerData);

        Animator anim = heroPortrait.GetComponent<Animator>();
        anim.runtimeAnimatorController = Resources.Load("Animations/" + playerData.heroType + "Controller") as RuntimeAnimatorController;

        SetLayerRecursively.SetLayer(heroPortrait, 5);

        heroPortrait.transform.SetParent(heroPortraitBackground.transform);
        heroPortrait.transform.localPosition = new Vector3(0, -55, 0);
        heroPortrait.transform.localScale = Vector3.one * 80;
    }
}
