using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject attackPrefab;

    public void InstantiateAttack(Damage damage)
    {
        GameObject attack = Instantiate(attackPrefab);
        attack.transform.SetParent(this.transform);
        attack.transform.position = this.transform.position;
        attack.transform.rotation = this.transform.rotation;
        attack.SendMessage("TakeDamageInformation", damage);
    }
}