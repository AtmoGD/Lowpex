using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCharacterController : MonoBehaviour
{
    public GameObject hero;
    public float turnSpeed;

    private Hat hat = 0;
    private void Start()
    {
        turnSpeed = 0;
    }
    private void Update()
    {
        hero.transform.Rotate(Vector3.up * turnSpeed);
    }
    public void TurnHero(float speed)
    {
        turnSpeed = speed;
    }
    public void ChangeHat(int dir)
    {
        int length = System.Enum.GetValues(typeof(Hat)).Length;
        int value = (int)hat + dir;
        hat = (Hat)(value >= length ? 0 : value < 0 ? length - 1 : value);
    }
}
