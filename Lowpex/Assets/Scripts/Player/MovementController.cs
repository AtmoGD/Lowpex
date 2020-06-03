using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MovementController : MonoBehaviour
{
    private Animator animator;

    private float actualSpeed = 0;
    private float maxSpeed = 15;

    private float rotateSpeed = 5;

    private float damping = 150;

    private bool isAbleToMove = true;
    private bool isMoving = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        animator.SetFloat("Speed", actualSpeed / maxSpeed);
        transform.localPosition = Vector3.Lerp(transform.position, transform.position + transform.forward, actualSpeed * Time.deltaTime);
    }
    public void Move(float speed)
    {
        if (speed < 0.1)
        {
            actualSpeed = actualSpeed > 0 ? actualSpeed - (damping * Time.fixedDeltaTime) : 0;
            actualSpeed = actualSpeed < 0 ? 0 : actualSpeed;
        } 
        else
        {
            actualSpeed = speed * maxSpeed;
        }
    }
    public void Rotate(Quaternion rotation)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
    }
}
