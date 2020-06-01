﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float followSpeed = 3f;
    public float rotationSpeed = 3f;
    public float movementSpeed = 10f;
    public float zoomSpeed = 150f;

    public Vector3 offset = new Vector3(0, 10, -10);
    public float distance = 10;

    private GameObject target;

    public void FollowTarget(GameObject target)
    {
        this.target = target;
    }
    void Update()
    {
        if (!target)
            return;

        FollowPlayer();

        LookAtTarget();
    }
    public void ZoomIn()
    {
        distance = Mathf.Clamp(distance - (zoomSpeed * Time.deltaTime), 5, 30);
    }
    public void ZoomOut()
    {
        Debug.Log("ZoomOut");
        distance = Mathf.Clamp(distance + (zoomSpeed * Time.deltaTime), 5, 30);
    }
    public void Move(Vector2 direction)
    {
        Vector3 newPos = transform.position - target.transform.position;
        newPos = Quaternion.Euler(direction.y * movementSpeed * Time.deltaTime, direction.x * movementSpeed * Time.deltaTime, 0) * newPos;

        newPos = Vector3.Normalize(newPos) * distance;
        offset = newPos;
    }
    private void LookAtTarget()
    {
        Quaternion OriginalRot = transform.rotation;
        transform.LookAt(target.transform);
        Quaternion NewRot = transform.rotation;
        transform.rotation = OriginalRot;
        transform.rotation = Quaternion.Lerp(transform.rotation, NewRot, rotationSpeed * Time.deltaTime);
    }
    private void FollowPlayer()
    {
        offset = Vector3.Normalize(offset) * distance;
        Vector3 targetPos = Vector3.Lerp(transform.position, target.transform.position + offset, followSpeed * Time.deltaTime);
        Vector3 newPos = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);

        transform.position = newPos;

    }
}
