using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MovementController : MonoBehaviour
{
    private PlayerData playerData;

    private Animator animator;
    private CameraController cameraController;

    private float actualSpeed = 0;

    private float damping = 30;
    private float rotationSpeed = 3;

    private Quaternion moveDirection;
    private Quaternion lookDirection;

    public void Init(PlayerData playerData)
    {
        this.playerData = playerData;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    private void Update()
    {
        if (this.playerData != null)
        {
            Debug.Log("Here");
            this.playerData.position = transform.position;
        }

        if (cameraController)
            cameraController.SetMoveDirection(moveDirection);

        animator.SetFloat("Speed", actualSpeed / playerData.speed);

        Quaternion oldRotation = transform.rotation;

        transform.rotation = moveDirection;
        transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward, actualSpeed * Time.deltaTime);

        transform.rotation = oldRotation;

        transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, rotationSpeed * Time.deltaTime);

        actualSpeed = actualSpeed > 0 ? actualSpeed - (damping * Time.fixedDeltaTime) : 0;
        actualSpeed = actualSpeed < 0 ? 0 : actualSpeed;
    }
    public void Move(float speed)
    {
        actualSpeed = speed * playerData.speed;
    }
    public void SetMoveDirection(Quaternion direction)
    {
        moveDirection = direction;
        lookDirection = direction;
    }
    public void SetLookDirection(Quaternion direction)
    {
        lookDirection = direction;
    }
    public void Rotate(Quaternion rotation)
    {
        lookDirection = rotation;
    }
}
