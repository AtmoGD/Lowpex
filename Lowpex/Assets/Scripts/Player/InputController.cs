using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class InputController : MonoBehaviour
{
    private FixedJoystick movementJoystick;

    private GameObject target;
    private GameObject camera;

    private float distance = 0;
    public void TakeMovementJoystick(FixedJoystick movementJoystick)
    {
        this.movementJoystick = movementJoystick;
    }
    public void TakeCamera(GameObject camera)
    {
        this.camera = camera;
    }
    public void TakeTarget(GameObject target)
    {
        this.target = target;
    }
    void Update()
    {
        if (!movementJoystick || !target)
            return;

        if (Input.touchCount > 0 && movementJoystick.Direction.magnitude == 0)
        {
            if (Input.touchCount == 2 && movementJoystick.Direction.magnitude == 0)
            {
                Debug.Log("here");
                ZoomCamera(Input.GetTouch(0), Input.GetTouch(1));
                return;
            }
            else
            {
                distance = 0;
            }


            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                RotateCamera(Input.GetTouch(0));
            }
        }
        MoveTarget(movementJoystick.Direction.magnitude);

        if (movementJoystick.Direction.magnitude != 0)
        {
            RotateTarget(movementJoystick.Direction);
        }

    }
    private void ZoomCamera(Touch firstTouch, Touch secondTouch)
    {
        if (firstTouch.phase != TouchPhase.Moved && secondTouch.phase != TouchPhase.Moved)
            return;

        if (distance == 0)
        {
            distance = (firstTouch.position - secondTouch.position).magnitude;
            return;
        }

        float newDistance = (firstTouch.position - secondTouch.position).magnitude;
        camera.SendMessage("Zoom", distance - newDistance);
    }
    private void RotateCamera(Touch touch)
    {
        camera.SendMessage("Move", touch.deltaPosition);
    }
    private void RotateTarget(Vector2 direction)
    {
        float angle = -(float)Mathf.Atan2(direction.y, direction.x);
        angle *= Mathf.Rad2Deg;
        angle += camera.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, angle + 90, 0);

        target.SendMessage("Rotate", rotation);
    }
    private void MoveTarget(float speed)
    {
        target.SendMessage("Move", speed);
    }
}
