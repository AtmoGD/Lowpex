using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MovementController))]
public class InputController : MonoBehaviour
{
    private FixedJoystick movementJoystick;
    private FixedJoystick attackJoystick;

    private GameObject target;
    private GameObject mainCamera;

    private float distance = 0;
    public void TakeMovementJoystick(FixedJoystick movementJoystick)
    {
        this.movementJoystick = movementJoystick;
    }
    public void TakeAttackJoystick(FixedJoystick attackJoystick)
    {
        this.attackJoystick = attackJoystick;
    }
    public void TakeCamera(GameObject camera)
    {
        this.mainCamera = camera;
    }
    public void TakeTarget(GameObject target)
    {
        this.target = target;
    }
    void Update()
    {
        if (!movementJoystick || !target || !attackJoystick || !mainCamera)
            return;


        if (Input.touchCount > 0 && movementJoystick.Direction.magnitude == 0 && attackJoystick.Direction.magnitude == 0)
        {
            if (Input.touchCount == 2)
            {
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

        if (movementJoystick.Direction.magnitude != 0)
        {
            target.SendMessage("Move", movementJoystick.Direction.magnitude);
            target.SendMessage("SetMoveDirection", GetRotation(movementJoystick.Direction));
        }

        if (attackJoystick.Direction.magnitude != 0)
        {
            target.SendMessage("SetLookDirection", GetRotation(attackJoystick.Direction));
            target.SendMessage("Attack");
        }


    }
    private Quaternion GetRotation(Vector2 direction)
    {
        if (direction.magnitude == 0)
        {
            return new Quaternion(0, 0, 0, 0);
        }

        float angle = -(float)Mathf.Atan2(direction.y, direction.x);
        angle *= Mathf.Rad2Deg;
        angle += mainCamera.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, angle + 90, 0);

        return rotation;
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
        mainCamera.SendMessage("Zoom", distance - newDistance);
    }
    private void RotateCamera(Touch touch)
    {
        mainCamera.SendMessage("Move", touch.deltaPosition.y);
    }

}
