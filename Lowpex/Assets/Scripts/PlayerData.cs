using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class PlayerData
{
    public int stateNumber;
    public HeroType heroType;

    #region Player look
    public Hat hat;
    public Skin skin;
    public Hair hair;
    public Cloth cloth;
    public Belt belt;
    public Gloves gloves;
    public Shoes shoes;
    public ShoulderPad shoulderPad;
    #endregion

    #region Player stats
    public int level;
    public int experience;
    public int gold;
    public int gems;
    public int health;
    public int maxHealth;
    public int mana;
    public int maxMana;
    public float attackSpeed;
    public float speed;
    public int crit;
    public int critResistance;
    public int blockChance;
    public float healthRecovery;
    public float manaRecovery;
    #endregion

    public List<Buff> buffs;

    public Vector3 position = new Vector3();

    public PrimaryWeapon primaryWeapon;
    public SecondaryWeapon secondaryWeapon;

    public List<Item> inventory = new List<Item>();

    public float GetAttackSpeed()
    {
        float attSpeed = attackSpeed;

        foreach (Buff buff in buffs)
        {
            attackSpeed -= buff.attackSpeed;
        }

        return attSpeed;
    }

    public Damage GetDamage()
    {
        Damage dmg = new Damage();
        dmg.damage = CalculateDamage();
        dmg.isCrit = isCrit();

        return dmg;
    }
    private int CalculateDamage()
    {
        int dmg = 0;

        foreach(Buff buff in buffs)
        {
            dmg += buff.damage;
        }

        return dmg;
    }

    private bool isCrit()
    {
        return false;
    }
}
