using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public string bestPlayerName;
    public int score;
    public int highScore;
    
    // class to store the data to save
    [System.Serializable]
    class SaveData
    {
        public string name;
        public int highScore;
    }
    
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadSavedData();       
    }

    public void LoadSavedData()
    {
        SaveData saveData = new SaveData();
        
        string path = Application.persistentDataPath + "/highScores.json";
        if(File.Exists(path))
        {
            string dataString = File.ReadAllText(Application.persistentDataPath + "/highScores.json");
        
            saveData = JsonUtility.FromJson<SaveData>(dataString);
        
            bestPlayerName = saveData.name;
            highScore = saveData.highScore;
        }
        else
        {
            bestPlayerName = "NoName";
            highScore = 0;
        }       
    }

    public void Save()
    {
        SaveData saveData = new SaveData();
        saveData.name = bestPlayerName;
        saveData.highScore = highScore;

        File.WriteAllText(Application.persistentDataPath + "/highScores.json", JsonUtility.ToJson(saveData));
    }

    public void UpdateHighScore(int points)
    {
        highScore = points;
        bestPlayerName = playerName;
    }
}
