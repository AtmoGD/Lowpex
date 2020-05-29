﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class CreateCharacterController : MonoBehaviour
{
    public GameObject hero;
    public Text heroTypeText;
    public float turnSpeed;

    private HeroType heroType = HeroType.Warrior;
    private Hat hat = Hat.Helm1;
    private Skin skin = Skin.Face3;
    private Hair hair = Hair.Hair2;
    private Cloth cloth = Cloth.Cloth1;
    private Belt belt = Belt.Belt3;
    private Gloves gloves = Gloves.Glove3;
    private Shoes shoes = Shoes.Shoe4;
    private ShoulderPad shoulderPad = ShoulderPad.None;

    private EquipController equ;
    private void Start()
    {
        equ = hero.GetComponent<EquipController>();
        turnSpeed = 0;
        equ.InitPlayer(Resources.Load("Data/GameState") as PlayerData);
        //UpdateHero();
    }
    private void Update()
    {

        hero.transform.Rotate(Vector3.up * turnSpeed);

    }
    public void SavePlayer()
    {

    }
    public void TurnHero(float speed)
    {
        turnSpeed = speed;
    }
    public void ChangeHeroType(int dir)
    {
        int length = System.Enum.GetValues(typeof(HeroType)).Length;
        int value = (int)heroType + dir;
        heroType = (HeroType)(value >= length ? 0 : value < 0 ? length - 1 : value);
        equ.playerData.heroType = heroType;

        switch (heroType)
        {
            case HeroType.Warrior:
                heroTypeText.text = "Krieger";
                equ.EquipPrimary(Resources.Load("Data/Weapons/BeginnerSword") as PrimaryWeapon);
                equ.EquipSecondary(Resources.Load("Data/Weapons/BeginnerShield") as SecondaryWeapon);
                break;
            case HeroType.Hunter:
                heroTypeText.text = "Bogenschütze";
                equ.EquipPrimary(Resources.Load("Data/Weapons/BeginnerBow") as PrimaryWeapon);
                equ.EquipSecondary(Resources.Load("Data/Weapons/BeginnerArrow") as SecondaryWeapon);
                break;
            case HeroType.Mage:
                heroTypeText.text = "Magier";
                equ.EquipPrimary(Resources.Load("Data/Weapons/BeginnerWand") as PrimaryWeapon);
                equ.EquipSecondary(Resources.Load("Data/Weapons/BeginnerBook") as SecondaryWeapon);
                break;
            default:
                break;
        }
    }
    public void ChangeHat(int dir)
    {
        int length = System.Enum.GetValues(typeof(Hat)).Length;
        int value = (int)hat + dir;
        hat = (Hat)(value >= length ? 0 : value < 0 ? length - 1 : value);
        equ.playerData.hat = hat;
        equ.UpdatePlayer();
    }
    public void ChangeSkin(int dir)
    {
        int length = System.Enum.GetValues(typeof(Skin)).Length;
        int value = (int)skin + dir;
        skin = (Skin)(value >= length ? 0 : value < 0 ? length - 1 : value);
        equ.playerData.skin = skin;
        equ.UpdatePlayer();
    }
    public void ChangeHair(int dir)
    {
        int length = System.Enum.GetValues(typeof(Hair)).Length;
        int value = (int)hair + dir;
        hair = (Hair)(value >= length ? 0 : value < 0 ? length - 1 : value);
        equ.playerData.hair = hair;
        equ.UpdatePlayer();
    }
    public void ChangeClothes(int dir)
    {
        int length = System.Enum.GetValues(typeof(Cloth)).Length;
        int value = (int)cloth + dir;
        cloth = (Cloth)(value >= length ? 0 : value < 0 ? length - 1 : value);
        equ.playerData.cloth = cloth;
        equ.UpdatePlayer();
    }
    public void ChangeBelt(int dir)
    {
        int length = System.Enum.GetValues(typeof(Belt)).Length;
        int value = (int)belt + dir;
        belt = (Belt)(value >= length ? 0 : value < 0 ? length - 1 : value);
        equ.playerData.belt = belt;
        equ.UpdatePlayer();
    }
    public void ChangeGloves(int dir)
    {
        int length = System.Enum.GetValues(typeof(Gloves)).Length;
        int value = (int)gloves + dir;
        gloves = (Gloves)(value >= length ? 0 : value < 0 ? length - 1 : value);
        equ.playerData.gloves = gloves;
        equ.UpdatePlayer();
    }
    public void ChangeShoes(int dir)
    {
        int length = System.Enum.GetValues(typeof(Shoes)).Length;
        int value = (int)shoes + dir;
        shoes = (Shoes)(value >= length ? 0 : value < 0 ? length - 1 : value);
        equ.playerData.shoes = shoes;
        equ.UpdatePlayer();
    }
    public void ChangeShoulderPad(int dir)
    {
        int length = System.Enum.GetValues(typeof(ShoulderPad)).Length;
        int value = (int)shoulderPad + dir;
        shoulderPad = (ShoulderPad)(value >= length ? 0 : value < 0 ? length - 1 : value);
        equ.playerData.shoulderPad = shoulderPad;
        equ.UpdatePlayer();
    }
}
