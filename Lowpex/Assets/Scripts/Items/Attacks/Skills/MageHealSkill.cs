using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageHealSkill : MonoBehaviour
{
    public float lifetime = 10f;
    void Start()
    {
        StartCoroutine(WaitTillDie());
    }

    IEnumerator WaitTillDie()
    {
        yield return new WaitForSecondsRealtime(lifetime);
        Destroy(this.gameObject);
    }
}
