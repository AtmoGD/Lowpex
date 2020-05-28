using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class StateController : MonoBehaviour
{
    public static void SavePlayer(SerializablePlayerData player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, player);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.data";
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

    public static void createNewGameState(HeroType type)
    {
        SerializablePlayerData data = new SerializablePlayerData(type);
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, data);
        stream.Close();
    }
}
