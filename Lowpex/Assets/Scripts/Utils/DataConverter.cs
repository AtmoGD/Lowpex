using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public static class DataConverter
{
    public static SerializablePlayerData ConvertFromPlayerData(PlayerData data)
    {
        SerializablePlayerData output = new SerializablePlayerData(data.heroType)
        {
            level = data.level,
            experience = data.experience,
            health = data.health,
            mana = data.mana,
            speed = data.speed,
            crit = data.crit,
            critResistance = data.critResistance,
            blockChance = data.blockChance,
            healthRecovery = data.healthRecovery,
            manaRecovery = data.manaRecovery
        };
        return output;
    }
    public static PlayerData ConvertToPlayerData(SerializablePlayerData data)
    {
        PlayerData output = Resources.Load("Data/GameState") as  PlayerData;
        switch (data.heroType)
        {
            case "Warrior":
                output.heroType = HeroType.Warrior;
                break;
            case "Hunter":
                output.heroType = HeroType.Hunter;
                break;
            case "Mage":
                output.heroType = HeroType.Mage;
                break;
            default:
                output.heroType = HeroType.Warrior;
                Debug.Log("#00001 Cannot Load Player data");
                break;
        }
        output.level = data.level;
        output.experience = data.experience;
        output.health = data.health;
        output.mana = data.mana;
        output.speed = data.speed;
        output.crit = data.crit;
        output.critResistance = data.critResistance;
        output.blockChance = data.blockChance;
        output.healthRecovery = data.healthRecovery;
        output.manaRecovery = data.manaRecovery;

        return output;
    }
}
