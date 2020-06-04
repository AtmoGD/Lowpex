using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public PlayerData firstGameState;
    public PlayerData secondGameState;
    public PlayerData thirdGameState;

    public GameObject platform;

    private float activeState = 0;

    public float rotationSpeed = 0.0001f;

    private bool isRotating = false;

    private float targetAngle = 0;

    void Update()
    {
        if (!isRotating && Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (Input.GetTouch(0).deltaPosition.x < 0)
                {
                    TurnLeft();
                }
                else
                {
                    TurnRight();
                }
                isRotating = true;
            }
        }
        Rotate();
    }
    private void TurnLeft()
    {
        activeState = (activeState + 2) % 3;
        targetAngle = (activeState + 1) * 120 % 360;
        rotationSpeed = rotationSpeed < 0 ? -rotationSpeed : rotationSpeed;

    }
    private void TurnRight()
    {
        activeState = (activeState + 1) % 3;
        targetAngle = (activeState + 1) * 120 % 360;
        rotationSpeed = rotationSpeed > 0 ? -rotationSpeed : rotationSpeed;
    }
    private void Rotate()
    {
        if (transform.rotation.eulerAngles.y != targetAngle)
        {
            Quaternion rot = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, targetAngle, 0)), rotationSpeed * Time.deltaTime);
            platform.transform.rotation = rot;
        } 
        else
        {
            isRotating = false;
        }
    }
}
