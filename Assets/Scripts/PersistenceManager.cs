using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;
    public string playerName;
    public int score;
    public string bestPlayer;
    public int bestScore;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    public void SaveData(string playerName, int score)
    {
        SaveData data = new SaveData();

        if(score > bestScore)
        {
            data.bestPlayer = playerName;
            data.bestScore = score;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + "/saved-data.json", json);
        }

        /*// one line file. Line is replaced if score > bestScore
        File.WriteAllText(Application.persistentDataPath + "/saved.json", $"Best Score : {playerName} : {bestScore}");*/
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/saved-data.json";
        if (File.Exists(path))
        {
            string jsonString = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonString);
            bestPlayer = data.bestPlayer;
            bestScore = data.bestScore;
            playerName = "";
            score = 0;
        }
        else
        {
            bestPlayer = "";
            bestScore = 0;
        }
        //return File.ReadAllText(Application.persistentDataPath + "/saved.json"); //.txt
    }

    /*public int GetBestScore()
    {
        string savedLine = LoadData();
        return Convert.ToInt16(savedLine.Split(':')[2].Trim());
    }*/
}

[Serializable]
class SaveData
{
    public string bestPlayer;
    public int bestScore;
}
