using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MovementController : MonoBehaviour
{
    private Animator animator;
    private CameraController cameraController;

    private float actualSpeed = 0;
    private float maxSpeed = 15;

    private float damping = 150;

    private Quaternion moveDirection;
    private Quaternion lookDirection;

    private void Start()
    {
        animator = GetComponent<Animator>();
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    private void Update()
    {
        if (cameraController)
            cameraController.SetMoveDirection(moveDirection);

        animator.SetFloat("Speed", actualSpeed / maxSpeed);
        

        transform.rotation = moveDirection;
        transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward, actualSpeed * Time.deltaTime);

        transform.rotation = lookDirection;

        actualSpeed = actualSpeed > 0 ? actualSpeed - (damping * Time.fixedDeltaTime) : 0;
        actualSpeed = actualSpeed < 0 ? 0 : actualSpeed;
    }
    public void Move(float speed)
    {

        actualSpeed = speed * maxSpeed;
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
