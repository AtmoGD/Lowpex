using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAttack : MonoBehaviour
{
    public float speed;
    public float lifetime = 2f;

    private Damage damage;

    public void TakeDamageInformation(Damage dmg)
    {
        damage = dmg;
        StartCoroutine(DieCoroutine());
    }
    void Update()
    {
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }

    IEnumerator DieCoroutine()
    {
        yield return new WaitForSecondsRealtime(lifetime);
        Destroy(this.gameObject);
    }
}
