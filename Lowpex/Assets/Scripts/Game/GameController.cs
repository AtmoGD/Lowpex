using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject heroPrefab;
    public FixedJoystick movementJoystick;
    public FixedJoystick attackJoystick;

    public GameObject heroPortraitBackground;

    private PlayerData playerData;
    private GameObject hero;
    private Camera mainCamera;
    private void Start()
    {
        this.playerData = StateController.LoadActualPlayer();
        InitHero(playerData);
        InitHeroPortrait(playerData);
    }
    private void InitHero(PlayerData playerData)
    {
        hero = Instantiate(heroPrefab);
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
    public void UseSkill(int skill)
    {
        switch (skill)
        {
            case 0:
                hero.SendMessage("UseFirstSkill");
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }
}
