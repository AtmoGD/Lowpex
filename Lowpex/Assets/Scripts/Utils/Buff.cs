using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new buff", menuName = "Data/Buff")]
public class Buff : ScriptableObject
{
    public string buffName;
    public int damage;
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
