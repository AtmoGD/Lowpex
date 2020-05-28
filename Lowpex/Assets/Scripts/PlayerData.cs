using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player Data")]
public class PlayerData : ScriptableObject
{
    public HeroType heroType;
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

    public Buff buffs;

    public Vector3 position;

    public PrimaryWeapon primaryWeapon;
    public SecondaryWeapon secondaryWeapon;

    public List<Item> inventory = new List<Item>();
}
