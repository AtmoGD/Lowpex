using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;

public class StateController : MonoBehaviour
{
    public static void SavePlayer(SerializablePlayerData player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player" + player.stateNumber + ".data";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, player);
        stream.Close();
    }

    public static PlayerData[] LoadAllPlayer()
    {
        PlayerData[] datas = null;
        for (int i = 0; i < 3; i++)
        {
            string path = Application.persistentDataPath + "/player" + i + ".data";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                SerializablePlayerData data = formatter.Deserialize(stream) as SerializablePlayerData;
                stream.Close();

                PlayerData playerData = DataConverter.ConvertToPlayerData(data);

                if (datas == null)
                {
                    datas = new PlayerData[1];
                    datas[0] = playerData;
                } else
                {
                    PlayerData[] temp = new PlayerData[datas.Length];
                    for (int x = 0; x < datas.Length; x++)
                    {
                        temp[x] = datas[x];
                    }
                    datas[datas.Length - 1] = playerData;
                }
            }
            else
            {
                Debug.LogError("Save not found");
                return null;
            }
        }
        return datas;
    }
    public static PlayerData LoadPlayer(int stateNumber)
    {
        string path = Application.persistentDataPath + "/player" + stateNumber + ".data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SerializablePlayerData data = formatter.Deserialize(stream) as SerializablePlayerData;
            stream.Close();

            PlayerData playerData = DataConverter.ConvertToPlayerData(data);

            return playerData;
        }
        else
        {
            Debug.LogError("Save not found");
            return null;
        }
    }
    public static int createNewGameState(HeroType type)
    {
        PlayerData[] pData = LoadAllPlayer();
        int stateNumber = pData == null ? 0 : pData.Length - 1;
        SerializablePlayerData data = new SerializablePlayerData(type, stateNumber);
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
        return stateNumber;
    }
}
