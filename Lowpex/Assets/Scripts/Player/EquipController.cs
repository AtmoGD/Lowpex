using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipController : MonoBehaviour
{
    public PlayerData playerData;

    public void InitPlayer(PlayerData data)
    {
        playerData = data;
        UpdatePlayer();
    }
    private GameObject GetPrimary()
    {
        foreach (Transform obj in transform.GetComponentsInChildren<Transform>(true))
        {
            if (obj.name == "weaponShield_" + (playerData.heroType == HeroType.Hunter ? "l" : "r"))
                return obj.gameObject;
        }
        return null;
    }
    private GameObject GetSecondary()
    {
        foreach (Transform obj in transform.GetComponentsInChildren<Transform>(true))
        {
            if (obj.name == "weaponShield_" + (playerData.heroType == HeroType.Hunter ? "r" : "l"))
                return obj.gameObject;
        }
        return null;
    }
    public void EquipPrimary(PrimaryWeapon weapon)
    {
        ClearPrimary();
        GameObject newWeapon = Instantiate(weapon.itemPrefab);
        newWeapon.transform.SetParent(GetPrimary().transform);
        newWeapon.transform.localRotation = Quaternion.identity;
        newWeapon.transform.localPosition = new Vector3(0, 0, 0);
        newWeapon.transform.localScale = new Vector3(1, 1, 1);
    }
    public void EquipSecondary(SecondaryWeapon weapon)
    {
        ClearSecondary();
        GameObject newWeapon = Instantiate(weapon.itemPrefab);
        newWeapon.transform.SetParent(GetSecondary().transform);
        newWeapon.transform.localRotation = Quaternion.identity;
        newWeapon.transform.localPosition = new Vector3(0, 0, 0);
        newWeapon.transform.localScale = new Vector3(1, 1, 1);
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

            if (!obj.parent || obj.parent.name != "Hero" || obj.name == "root")
                continue;

            obj.gameObject.SetActive(false);
        }

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
