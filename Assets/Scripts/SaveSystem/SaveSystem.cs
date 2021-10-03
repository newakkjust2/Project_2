using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static int indexOfSong;
    public static bool loop;
    public static float volume = 0.2f;
     
    public static GameObject sceneLoaderGameObject;
    
    public static readonly Dictionary<string, bool> 
        likes = new Dictionary<string, bool>(), 
        dislikes = new Dictionary<string, bool>();

    public static void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.saving";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData();
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void LoadData()
    {
        string path = Application.persistentDataPath + "/data.saving";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData a = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            loop = a.loop;
            indexOfSong = a.indexOfSong;
            volume = a.volume;
        }
        else
        {
            return;
        }
    }
}
