using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Primary", menuName = "Data/Primary")]
public class PrimaryWeapon : Weapon
{
    public void Attack()
    {
        Debug.Log("Im Here");
    }
}
