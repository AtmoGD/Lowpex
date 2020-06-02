using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float followSpeed;
    public float rotationSpeed;
    public float movementSpeed;
    public float zoomSpeed;

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
    public void Zoom(float speed)
    {
        distance = Mathf.Clamp(distance + (zoomSpeed * speed * Time.deltaTime), 5, 30);
    }
    public void Move(Vector2 direction)
    {
        direction *= movementSpeed;

        Vector3 newPos = transform.position - target.transform.position;
        newPos = Quaternion.Euler(-direction.y, direction.x, 0) * newPos;
        newPos = Vector3.Normalize(newPos) * distance;

        offset = Vector3.Lerp(offset, newPos, movementSpeed);

        offset.y = Mathf.Clamp(offset.y, 1, 15);
    }
    private void LookAtTarget()
    {
        Quaternion originalRot = transform.rotation;
        transform.LookAt(target.transform.position + (Vector3.up * 4));
        Quaternion newRot = transform.rotation;
        transform.rotation = originalRot;
        transform.rotation = Quaternion.Lerp(transform.rotation, newRot, rotationSpeed * Time.deltaTime);
    }
    private void FollowPlayer()
    {
        offset = Vector3.Normalize(offset) * distance;
        //Vector3 targetPos = Vector3.Lerp(transform.position, target.transform.position + offset, followSpeed * Time.deltaTime);
        //Vector3 newPos = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
        Vector3 newPos = Vector3.Lerp(transform.position, target.transform.position + offset, followSpeed * Time.deltaTime);
        transform.position = newPos;

    }
}
