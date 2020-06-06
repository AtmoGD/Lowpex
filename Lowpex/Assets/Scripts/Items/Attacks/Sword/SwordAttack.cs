using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float lifetime = 0.1f;

    private Damage damage;

    public void TakeDamageInformation(Damage dmg)
    {
        damage = dmg;
        StartCoroutine(DieCoroutine());

    }
    void Update()
    {
    }

    IEnumerator DieCoroutine()
    {
        yield return new WaitForSecondsRealtime(lifetime);
        Destroy(this.gameObject);
    }
}
