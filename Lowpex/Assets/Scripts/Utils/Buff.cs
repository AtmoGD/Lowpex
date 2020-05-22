using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : ScriptableObject
{
    public string buffName;
    public int health;
    public int mana;
    public float attackSpeed;
    public float speed;
    public int crit;
    public int critResistance;
    public int blockChance;
    public float healthRecovery;
    public float manaRecovery;
    public float expMultiplier;
}
