using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class CreateCharacterController : MonoBehaviour
{
    public GameObject hero;
    public float turnSpeed;


    private Hat hat = Hat.Helm1;
    private Skin skin = Skin.Face3;
    private Hair hair = Hair.Hair2;
    private Cloth cloth = Cloth.Cloth1;
    private Belt belt = Belt.Belt3;
    private Gloves gloves = Gloves.Glove3;
    private Shoes shoes = Shoes.Shoe4;
    private ShoulderPad shoulderPad = ShoulderPad.None;

    private void Start()
    {
        turnSpeed = 0;
        UpdateHero();
    }
    private void Update()
    {

        hero.transform.Rotate(Vector3.up * turnSpeed);

    }
    public void TurnHero(float speed)
    {
        turnSpeed = speed;
    }
    private void UpdateHero()
    {
        updateSkin();
        updateHair();
        updateHat();
        updateClothes();
        updateBelt();
        updateGloves();
        updateShoes();
        updateShoulderPad();
    }
    public void ChangeHat(int dir)
    {
        int length = System.Enum.GetValues(typeof(Hat)).Length;
        int value = (int)hat + dir;
        hat = (Hat)(value >= length ? 0 : value < 0 ? length - 1 : value);
        updateHat();
    }
    private void updateHat()
    {
        foreach (string obj in System.Enum.GetNames(typeof(Hat)))
        {
            hero.transform.Find(obj)?.gameObject.SetActive(obj == hat.ToString());
        }
        updateHair();
    }
    public void ChangeSkin(int dir)
    {
        int length = System.Enum.GetValues(typeof(Skin)).Length;
        int value = (int)skin + dir;
        skin = (Skin)(value >= length ? 0 : value < 0 ? length - 1 : value);
        updateSkin();
    }
    private void updateSkin()
    {
        foreach (string obj in System.Enum.GetNames(typeof(Skin)))
        {
            hero.transform.Find(obj)?.gameObject.SetActive(obj == skin.ToString());
        }
    }
    public void ChangeHair(int dir)
    {
        hero.transform.Find(hair.ToString())?.gameObject.SetActive(false);
        hero.transform.Find(hair.ToString() + "Half")?.gameObject.SetActive(false);

        int length = System.Enum.GetValues(typeof(Hair)).Length;
        int value = (int)hair + dir;
        hair = (Hair)(value >= length ? 0 : value < 0 ? length - 1 : value);
        updateHair();
    }
    private void updateHair()
    {

        if (hat == Hat.None || hat == Hat.Crown1 || hat == Hat.Crown2 || hat == Hat.Crown3 || hat == Hat.Crown4)
        {
            hero.transform.Find(hair.ToString() + "Half")?.gameObject.SetActive(false);
            hero.transform.Find(hair.ToString())?.gameObject.SetActive(true);
        }
        else if(hat == Hat.Helm4 || hat == Hat.Helm5 || hat == Hat.Helm6 || hat == Hat.Helm7)
        {
            hero.transform.Find(hair.ToString() + "Half")?.gameObject.SetActive(false);
            hero.transform.Find(hair.ToString())?.gameObject.SetActive(false);
        }
        else
        {
            hero.transform.Find(hair.ToString())?.gameObject.SetActive(false);
            hero.transform.Find(hair.ToString() + "Half")?.gameObject.SetActive(true);
        }
    }
    public void ChangeClothes(int dir)
    {
        int length = System.Enum.GetValues(typeof(Cloth)).Length;
        int value = (int)cloth + dir;
        cloth = (Cloth)(value >= length ? 0 : value < 0 ? length - 1 : value);
        updateClothes();
    }
    private void updateClothes()
    {
        foreach (string obj in System.Enum.GetNames(typeof(Cloth)))
        {
            hero.transform.Find(obj)?.gameObject.SetActive(obj == cloth.ToString());
        }
    }
    public void ChangeBelt(int dir)
    {
        int length = System.Enum.GetValues(typeof(Belt)).Length;
        int value = (int)belt + dir;
        belt = (Belt)(value >= length ? 0 : value < 0 ? length - 1 : value);
        updateBelt();
    }
    private void updateBelt()
    {
        foreach (string obj in System.Enum.GetNames(typeof(Belt)))
        {
            hero.transform.Find(obj)?.gameObject.SetActive(obj == belt.ToString());
        }
    }
    public void ChangeGloves(int dir)
    {
        int length = System.Enum.GetValues(typeof(Gloves)).Length;
        int value = (int)gloves + dir;
        gloves = (Gloves)(value >= length ? 0 : value < 0 ? length - 1 : value);
        updateGloves();
    }
    private void updateGloves()
    {
        foreach (string obj in System.Enum.GetNames(typeof(Gloves)))
        {
            hero.transform.Find(obj)?.gameObject.SetActive(obj == gloves.ToString());
        }
    }
    public void ChangeShoes(int dir)
    {
        int length = System.Enum.GetValues(typeof(Shoes)).Length;
        int value = (int)shoes + dir;
        shoes = (Shoes)(value >= length ? 0 : value < 0 ? length - 1 : value);
        updateShoes();
    }
    private void updateShoes()
    {
        foreach (string obj in System.Enum.GetNames(typeof(Shoes)))
        {
            hero.transform.Find(obj)?.gameObject.SetActive(obj == shoes.ToString());
        }
    }
    public void ChangeShoulderPad(int dir)
    {
        int length = System.Enum.GetValues(typeof(ShoulderPad)).Length;
        int value = (int)shoulderPad + dir;
        shoulderPad = (ShoulderPad)(value >= length ? 0 : value < 0 ? length - 1 : value);
        updateShoulderPad();
    }
    private void updateShoulderPad()
    {
        foreach (string obj in System.Enum.GetNames(typeof(ShoulderPad)))
        {
            hero.transform.Find(obj)?.gameObject.SetActive(obj == shoulderPad.ToString());
        }
    }
}
