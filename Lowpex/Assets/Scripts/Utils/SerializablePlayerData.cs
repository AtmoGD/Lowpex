using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializablePlayerData
{
    public int stateNumber;
    public string heroType;
    public int level;
    public int experience;
    public int health;
    public int mana;
    public float speed;
    public int crit;
    public int critResistance;
    public int blockChance;
    public float healthRecovery;
    public float manaRecovery;

    public SerializablePlayerData(HeroType type, int stateNum)
    {
        stateNumber = stateNum;
        heroType = type.ToString();
        level = 1;
        experience = 0;
        health = 200;
        mana = 200;
        speed = 5;
        crit = 0;
        critResistance = 0;
        blockChance = 0;
        healthRecovery = 1;
        manaRecovery = 1;
    }
}
