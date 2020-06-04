using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public static class DataConverter
{
    public static SerializablePlayerData ConvertFromPlayerData(PlayerData data)
    {
        SerializablePlayerData output = new SerializablePlayerData(data.heroType, data.stateNumber)
        {
            level = data.level,
            experience = data.experience,
            gold = data.gold,
            gems = data.gems,
            health = data.health,
            maxHealth = data.maxHealth,
            mana = data.mana,
            maxMana = data.maxMana,
            attackSpeed = data.attackSpeed,
            speed = data.speed,
            crit = data.crit,
            critResistance = data.critResistance,
            blockChance = data.blockChance,
            healthRecovery = data.healthRecovery,
            manaRecovery = data.manaRecovery,

            hat = data.hat.ToString(),
            skin = data.skin.ToString(),
            hair = data.hair.ToString(),
            cloth = data.cloth.ToString(),
            belt = data.belt.ToString(),
            gloves = data.gloves.ToString(),
            shoes = data.shoes.ToString(),
            shoulderPad = data.shoulderPad.ToString(),

            primaryWeapon = data.primaryWeapon.name,
            secondaryWeapon = data.secondaryWeapon.name

            //TODO Inventory

        };
        output.position[0] = data.position.x;
        output.position[1] = data.position.y;
        output.position[2] = data.position.z;

        return output;
    }
    public static PlayerData ConvertToPlayerData(SerializablePlayerData data)
    {
        PlayerData output = new PlayerData
        {
            stateNumber = data.stateNumber,
            heroType = (HeroType)System.Enum.Parse(typeof(HeroType), data.heroType),

            level = data.level,
            experience = data.experience,
            gold = data.gold,
            gems = data.gems,
            health = data.health,
            maxHealth = data.maxHealth,
            mana = data.mana,
            maxMana = data.maxMana,
            attackSpeed = data.attackSpeed,
            speed = data.speed,
            crit = data.crit,
            critResistance = data.critResistance,
            blockChance = data.blockChance,
            healthRecovery = data.healthRecovery,
            manaRecovery = data.manaRecovery,

            buffs = new List<Buff>(),

            hat = (Hat)System.Enum.Parse(typeof(Hat), data.hat),
            skin = (Skin)System.Enum.Parse(typeof(Skin), data.skin),
            hair = (Hair)System.Enum.Parse(typeof(Hair), data.hair),
            cloth = (Cloth)System.Enum.Parse(typeof(Cloth), data.cloth),
            belt = (Belt)System.Enum.Parse(typeof(Belt), data.belt),
            gloves = (Gloves)System.Enum.Parse(typeof(Gloves), data.gloves),
            shoes = (Shoes)System.Enum.Parse(typeof(Shoes), data.shoes),
            shoulderPad = (ShoulderPad)System.Enum.Parse(typeof(ShoulderPad), data.shoulderPad),

            primaryWeapon = Resources.Load("Data/Weapons/" + data.primaryWeapon) as PrimaryWeapon,
            secondaryWeapon = Resources.Load("Data/Weapons/" + data.secondaryWeapon) as SecondaryWeapon
        };

        //TODO Inventory

        return output;
    }
}
