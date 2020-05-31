using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

[System.Serializable]
public class SerializablePlayerData
{
    public int stateNumber;
    public string heroType;

    public string hat;
    public string skin;
    public string hair;
    public string cloth;
    public string belt;
    public string gloves;
    public string shoes;
    public string shoulderPad;

    public int level;
    public int experience;
    public int gold;
    public int gems;
    public int health;
    public int mana;
    public float speed;
    public int crit;
    public int critResistance;
    public int blockChance;
    public float healthRecovery;
    public float manaRecovery;

    public float[] position;

    public string primaryWeapon;
    public string secondaryWeapon;

    public string[] inventory;


    public SerializablePlayerData(HeroType type, int stateNum)
    {
        stateNumber = stateNum;
        heroType = type.ToString();
        level = 1;
        experience = 0;
        gold = 0;
        gems = 0;
        health = 200;
        mana = 200;
        speed = 5;
        crit = 0;
        critResistance = 0;
        blockChance = 0;
        healthRecovery = 1;
        manaRecovery = 1;


        hat = "None";
        skin = "Face1";
        hair = "Hair1";
        cloth = "Cloth1";
        belt = "None";
        gloves = "Glove1";
        shoes = "Shoe1";
        shoulderPad = "None";

        position = new float[3];

        position[0] = 0;
        position[1] = 0;
        position[2] = 0;

        primaryWeapon = "BeginnerBow";
        secondaryWeapon = "BeginnerArrow";

        inventory = new string[0];
    }
}
