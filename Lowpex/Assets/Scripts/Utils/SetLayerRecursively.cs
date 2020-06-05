using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SetLayerRecursively
{
    public static void SetLayer(GameObject obj, int newLayer)
    {
        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            SetLayer(child.gameObject, newLayer);
        }
    }
}
