using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; private set; }
    
    // What we want to save
    public int currentCar;
    public int currentLevel;
    public int currentExp;
    public float volumeMusic;
    public float volumeCars;
        
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
        
        DontDestroyOnLoad(gameObject);
        Save();
        Load();
    }

    public void ResetGame()
        => File.Delete(Application.persistentDataPath + "/playerinfo.dat");
    

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerinfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.dat", FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage) bf.Deserialize(file);

            currentCar = data.currentCar;
            currentExp = data.currentExp;
            currentLevel = data.currentLevel;
            volumeMusic = data.volumeMusic;
            volumeCars = data.volumeCars;
            file.Close();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter(); // To encrypt our Save
        FileStream file = File.Create(Application.persistentDataPath + "/playerinfo.dat"); // Directory of save
        PlayerData_Storage data = new PlayerData_Storage(currentCar, currentExp, currentLevel, volumeMusic, volumeCars);

        bf.Serialize(file, data);
        file.Close();
    }
}

[Serializable]
class PlayerData_Storage
{
    public int currentCar;
    public int currentExp;
    public int currentLevel;
    public float volumeMusic;
    public float volumeCars;
    
    public PlayerData_Storage(int currentCar, int currentExp, int currentLevel, float volumeMusic, float volumeCars)
    {
        this.currentCar = currentCar;
        this.currentExp = currentExp;
        this.currentLevel = currentLevel;
        this.volumeMusic = volumeMusic;
        this.volumeCars = volumeCars;
    }
}
    
