using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject attackPrefab;

    public void InstantiateAttack(Damage damage)
    {
        GameObject attack = Instantiate(attackPrefab);
        attack.transform.position = damage.owner.GetComponent<EquipController>().GetPrimary().transform.position;
        attack.transform.rotation = damage.owner.transform.localRotation;
        attack.SendMessage("TakeDamageInformation", damage);
    }
}
