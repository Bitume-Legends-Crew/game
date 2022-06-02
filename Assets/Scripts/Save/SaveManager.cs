using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; private set; }
    
    // What we want to save
    public int currentCar;
    public int currentLevel;
    public int currentExp;
        
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        else
            instance = this;
        
        DontDestroyOnLoad(gameObject); // It doesn't get destroyed so can Save
        Load();
    }

    public void ResetGame()
    {
        File.Delete(Application.persistentDataPath + "/playerinfo.dat");
    }

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
            
            file.Close();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter(); // To encrypt our Save
        FileStream file = File.Create(Application.persistentDataPath + "/playerinfo.dat"); // Directory of save
        PlayerData_Storage data = new PlayerData_Storage(currentCar, currentExp, currentLevel);

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
    
    public PlayerData_Storage(int currentCar, int currentExp, int currentLevel)
    {
        this.currentCar = currentCar;
        this.currentExp = currentExp;
        this.currentLevel = currentLevel;
    }
}
    
