using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataPersist : MonoBehaviour
{
    public static DataPersist Instance;

    public string playerName;

    public string bestPlayerNameAndScore; //To be saved in Json
    public int bestHighScore;

    [System.Serializable]
    class SaveData
    {
        public string bestPlayerNameAndScore;
        public int bestHighScore;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        //For resetting High Score during Test
        //ResetHighScore();
    }

    //Method to save json of best player name and score
    public void SaveHighScore(string newStats, int newHighScore)
    {
        SaveData data = new SaveData();
        data.bestPlayerNameAndScore = newStats;
        data.bestHighScore = newHighScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    //Method to retrieve json best player name and score
    public void GetHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestPlayerNameAndScore = data.bestPlayerNameAndScore;
            bestHighScore = data.bestHighScore;
        }
    }

    //Resetting High Score for Testing
    public void ResetHighScore()
    {
        SaveData data = new SaveData();
        data.bestPlayerNameAndScore = "";
        data.bestHighScore = 000;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}