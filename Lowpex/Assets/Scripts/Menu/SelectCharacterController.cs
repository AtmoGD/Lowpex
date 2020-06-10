using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectCharacterController : MonoBehaviour
{
    public PlayerData[] playerData = new PlayerData[3];

    public GameObject platforms;

    public GameObject firstPlatform;
    public GameObject secondPlatform;
    public GameObject thirdPlatform;

    public GameObject playerPrefab;
    public GameObject deleteButton;
    public Text buttonText;

    public int activePlatform = 0;
    public int activeState = -1;

    private bool isRotating = false;
    public float rotationSpeed;
    private float actualSpeed = 0;
    private float rotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        LoadPlayer();

        SetActiveState();
        buttonText.text = ActivePlatformExists() ? "Spiel Starten" : "Neues Spiel";
        deleteButton.SetActive(ActivePlatformExists());
    }

    void Update()
    {
        if (isRotating)
        {
            Rotate();
        }
    }

    private void LoadPlayer()
    {
        playerData = StateController.LoadAllPlayer();

        if (playerData == null)
            return;

        foreach (PlayerData player in this.playerData)
        {
            GameObject newState = Instantiate(playerPrefab);

            switch (player.stateNumber)
            {
                case 0:
                    newState.transform.SetParent(firstPlatform.transform);
                    break;
                case 1:
                    newState.transform.SetParent(secondPlatform.transform);
                    break;
                case 2:
                    newState.transform.SetParent(thirdPlatform.transform);
                    break;
                default:
                    break;
            }
            newState.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
            MenuHeroController controller = newState.AddComponent<MenuHeroController>();
            controller.SendMessage("InitPlayer", player);
            newState.transform.localPosition = new Vector3(0, 0, 0.045f);
            newState.AddComponent<LookForwardController>();
        }

    }
    public void ButtonClicked()
    {
        if (isRotating)
            return;

        if (ActivePlatformExists())
        {
            StateController.SaveActiveGameState(activeState);
            SceneManager.LoadScene(3);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
    public void DeleteActiveState()
    {
        /*
        StateController.DeleteAll();
        */
        StateController.DeleteState(activeState);
        SceneManager.LoadScene(1);
    }

    private void SetActiveState()
    {
        if (playerData == null)
        {
            activeState = -1;
            return;
        }

        foreach (PlayerData player in playerData)
        {
            if (activePlatform == player.stateNumber)
                activeState = player.stateNumber;
        }

        Debug.Log(activeState);
    }
    private bool ActivePlatformExists()
    {
        if (playerData == null)
            return false;

        foreach (PlayerData player in playerData)
        {
            if (activePlatform == player.stateNumber)
                return true;
        }

        return false;
    }

    public void TurnLeft()
    {
        if (isRotating)
            return;

        actualSpeed = rotationSpeed;
        activePlatform = activePlatform == 0 ? 2 : activePlatform - 1;
        isRotating = true;

        SetActiveState();
    }
    public void TurnRight()
    {
        if (isRotating)
            return;

        actualSpeed = -rotationSpeed;
        activePlatform = activePlatform == 2 ? 0 : activePlatform + 1;
        isRotating = true;

        SetActiveState();
    }

    private void Rotate()
    {
        platforms.transform.Rotate(Vector3.up, actualSpeed * Time.deltaTime);

        rotation += rotationSpeed * Time.deltaTime;

        if (rotation >= 120 || rotation <= -120)
        {
            platforms.transform.Rotate(Vector3.up, actualSpeed < 0 ? (rotation - 120) : -(rotation - 120));
            isRotating = false;
            rotation = 0;

            buttonText.text = ActivePlatformExists() ? "Spiel starten" : "Neues Spiel";
            deleteButton.SetActive(ActivePlatformExists());
        }
    }
}
