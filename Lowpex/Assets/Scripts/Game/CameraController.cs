using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target; 

    public float distance = 10.0f;
    public float height = 5.0f;
    public float heightDamping = 2.0f;
    public float rotationDamping = 1.0f;

    public float zoomSpeed = 3f;
    public float moveSpeed = 1f;

    private Quaternion direction;

    public void FollowTarget(GameObject target)
    {
        this.target = target;
    }
    public void Zoom(float speed)
    {
        distance = Mathf.Clamp(distance + (zoomSpeed * speed * Time.deltaTime), 1, 15);
    }
    public void Move(float direction)
    {
        height = Mathf.Clamp(height + (moveSpeed * direction * Time.deltaTime), 1, 15);
    }
    public void SetMoveDirection(Quaternion direction)
    {
        this.direction = direction;
    }
    void LateUpdate()
    {
        if (!target) 
            return;


        float wantedRotationAngle = direction.eulerAngles.y;
        float wantedHeight = target.transform.position.y + height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        transform.position = target.transform.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        transform.LookAt(target.transform.position + (target.transform.up));
      
    }

}
