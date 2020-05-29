using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInputController : MonoBehaviour
{
    public GameObject platforms;
    public GameObject firstPlatform;
    public GameObject secondPlatform;
    public GameObject thirdPlatform;
    public GameObject playerPrefab;

    public float rotationSpeed = 50f;
    public Text buttonText;

    public PlayerData[] playerData;

    private float actualSpeed = 0;
    private int activeState = 0;
    private bool isRotating = false;
    private float rotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        LoadPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(isRotating)
        {
            Rotate();
        }
    }
    private void LoadPlayer()
    {
        playerData = StateController.LoadAllPlayer();

        if (playerData == null)
            return;

        

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
            Debug.Log(rotation);
            platforms.transform.Rotate(Vector3.up, actualSpeed < 0 ? (rotation - 120) : -(rotation - 120));
            isRotating = false;
            rotation = 0;
        }
    }
}
