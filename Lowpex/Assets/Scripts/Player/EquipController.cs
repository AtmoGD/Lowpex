using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipController : MonoBehaviour
{
    public PlayerData playerData;

    private GameObject primaryWeapon;
    private GameObject secondaryWeapon;

    public void Init(PlayerData data)
    {
        playerData = data;
        UpdatePlayer();
    }
    public GameObject GetPrimaryWeapon()
    {
        return primaryWeapon;
    }
    public GameObject GetSecondaryWeapon()
    {
        return secondaryWeapon;
    }
    public GameObject GetPrimary()
    {
        foreach (Transform obj in transform.GetComponentsInChildren<Transform>(true))
        {
            if (obj.name == "weaponShield_" + (playerData.heroType == HeroType.Hunter ? "l" : "r"))
                return obj.gameObject;
        }
        return null;
    }
    public GameObject GetSecondary()
    {
        foreach (Transform obj in transform.GetComponentsInChildren<Transform>(true))
        {
            if (obj.name == "weaponShield_" + (playerData.heroType == HeroType.Hunter ? "r" : "l"))
                return obj.gameObject;
        }
        return null;
    }
    public void EquipPrimary()
    {
        if (!playerData.primaryWeapon)
            return;

        ClearPrimary();
        GameObject newWeapon = Instantiate(playerData.primaryWeapon.itemPrefab);
        GameObject primaryHand = GetPrimary();
        newWeapon.transform.SetParent(primaryHand.transform);
        newWeapon.transform.localRotation = Quaternion.identity;
        newWeapon.transform.localPosition = Vector3.zero;
        newWeapon.transform.localScale = Vector3.one;

        primaryWeapon = newWeapon;
    }
    public void EquipSecondary()
    {
        if (!playerData.secondaryWeapon)
            return;

        ClearSecondary();
        GameObject newWeapon = Instantiate(playerData.secondaryWeapon.itemPrefab);
        GameObject secondaryHand = GetSecondary();
        newWeapon.transform.SetParent(secondaryHand.transform);
        newWeapon.transform.localRotation = secondaryHand.transform.rotation;
        newWeapon.transform.localRotation = Quaternion.identity;
        newWeapon.transform.localPosition = Vector3.zero;
        newWeapon.transform.localScale = Vector3.one;

        secondaryWeapon = newWeapon;
    }
    public void ClearPrimary()
    {
        foreach (Transform obj in GetPrimary().transform.GetComponentsInChildren<Transform>()) {
            if (obj.name == GetPrimary().name)
                continue;

            Destroy(obj.gameObject);
        }
    }
    public void ClearSecondary()
    {
        foreach (Transform obj in GetSecondary().transform.GetComponentsInChildren<Transform>())
        {
            if (obj.name == GetSecondary().name)
                continue;

            Destroy(obj.gameObject);
        }
    }
    public void UpdatePlayer()
    {

        foreach (Transform obj in transform.GetComponentsInChildren<Transform>(true))
        {

            if (!obj.parent || obj.parent.name != transform.name || obj.name == "root")
                continue;

            obj.gameObject.SetActive(false);
        }

        EquipPrimary();
        EquipSecondary();

        transform.Find(playerData.hat.ToString())?.gameObject.SetActive(true);
        transform.Find(playerData.skin.ToString()).gameObject.SetActive(true);
        transform.Find(playerData.cloth.ToString()).gameObject.SetActive(true);
        transform.Find(playerData.belt.ToString())?.gameObject.SetActive(true);
        transform.Find(playerData.gloves.ToString()).gameObject.SetActive(true);
        transform.Find(playerData.shoes.ToString()).gameObject.SetActive(true);
        transform.Find(playerData.shoulderPad.ToString())?.gameObject.SetActive(true);

        Hat hat = playerData.hat;
        Hair hair = playerData.hair;

        if (hat == Hat.None || hat == Hat.Crown1 || hat == Hat.Crown2 || hat == Hat.Crown3 || hat == Hat.Crown4)
            transform.Find(hair.ToString()).gameObject.SetActive(true);

        else if (hat == Hat.Helm4 || hat == Hat.Helm5 || hat == Hat.Helm6 || hat == Hat.Helm7)
            return;

        else
            transform.Find(hair.ToString() + "Half").gameObject.SetActive(true);
    }
}
