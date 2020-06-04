using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuInputController : MonoBehaviour
{
    public GameObject platforms;
    public GameObject firstPlatform;
    public GameObject secondPlatform;
    public GameObject thirdPlatform;
    public GameObject playerPrefab;
    public GameObject deleteButton;

    public float rotationSpeed = 50f;
    public Text buttonText;
    
    public PlayerData[] playerData;

    private int activeState = 0;
    private int firstState;
    private int secondState;
    private int thirdState;

    private float actualSpeed = 0;
    private bool isRotating = false;
    private float rotation = 0;

    void Start()
    {
        LoadPlayer();

        if (playerData == null)
            buttonText.text = "Neues Spiel";
        else 
            buttonText.text = activeState < playerData.Length ? "Spiel starten" : "Neues Spiel";
    }

    void Update()
    {
        if(isRotating)
        {
            Rotate();
        }
    }
    public void ButtonClicked()
    {
        if (isRotating)
            return;

        if (playerData != null && activeState < playerData.Length)
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
        switch (activeState)
        {
            case 0:
                StateController.DeleteState(firstState);
                break;
            case 1:
                StateController.DeleteState(secondState);
                break;
            case 2:
                StateController.DeleteState(thirdState);
                break;
        }
        SceneManager.LoadScene(1);
    }
    private void LoadPlayer()
    {
        playerData = StateController.LoadAllPlayer();

        if (playerData == null)
            return;

        GameObject stateOne = Instantiate(playerPrefab);
        stateOne.transform.localScale = new Vector3(8, 8, 8);
        stateOne.transform.SetParent(firstPlatform.transform);
        MenuHeroController controller = stateOne.AddComponent<MenuHeroController>();
        controller.SendMessage("InitPlayer", playerData[0]);
        stateOne.transform.localPosition = new Vector3(0, 0, 0.045f);
        stateOne.AddComponent<LookForwardController>();
        firstState = playerData[0].stateNumber;

        if (playerData.Length < 2)
            return;

        GameObject stateTwo = Instantiate(playerPrefab);
        stateTwo.transform.localScale = new Vector3(8, 8, 8);
        stateTwo.transform.SetParent(secondPlatform.transform);
        controller = stateTwo.AddComponent<MenuHeroController>();
        controller.SendMessage("InitPlayer", playerData[1]);
        stateTwo.transform.localPosition = new Vector3(0, 0, 0.045f);
        stateTwo.AddComponent<LookForwardController>();
        secondState = playerData[1].stateNumber;

        if (playerData.Length < 3)
            return;

        GameObject stateThree = Instantiate(playerPrefab);
        stateThree.transform.localScale = new Vector3(8, 8, 8);
        stateThree.transform.SetParent(thirdPlatform.transform);
        controller = stateThree.AddComponent<MenuHeroController>();
        controller.SendMessage("InitPlayer", playerData[2]);
        stateThree.transform.localPosition = new Vector3(0, 0, 0.045f);
        stateThree.AddComponent<LookForwardController>();
        thirdState = playerData[2].stateNumber;
    }
    public void TurnLeft()
    {
        if (isRotating)
            return;

        actualSpeed = rotationSpeed;
        activeState = activeState == 0 ? 2 : activeState - 1;
        isRotating = true;
    }
    public void TurnRight()
    {
        if (isRotating)
            return;

        actualSpeed = -rotationSpeed;
        activeState = activeState == 2 ? 0 : activeState + 1;
        isRotating = true;
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

            buttonText.text = activeState < playerData.Length ? "Spiel starten" : "Neues Spiel";
            deleteButton.SetActive(activeState < playerData.Length);
        }
    }
}
