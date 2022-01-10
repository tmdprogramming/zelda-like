using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class GameControl : MonoBehaviour
{
    public static GameControl control;
    public float x;
    public float y;
    public float z;
    public string scene;
    public int[] id = new int[100];
    
    private void Awake()
    {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
    }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.x = x;
        data.y = y;
        data.z = z;
        data.id = id;
        data.scene = scene;
        

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            x = data.x;
            y = data.y;
            z = data.z;
            id = data.id;
            scene = data.scene;
        }
    }
}

[Serializable]
class PlayerData
{
    public float x;
    public float y;
    public float z;
    public int[] id = new int[100];
    public string scene;
}
