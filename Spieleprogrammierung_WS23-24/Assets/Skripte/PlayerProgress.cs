using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public static PlayerProgress instance;

  

// Wie viele Münzen hat der Speiler und welche Level
    [System.Serializable]
    public class PlayerData
    {
        public int coins;
       public List<LevelData> levelProgressList;
    }

    public PlayerData playerData;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InitializePlayerData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void InitializePlayerData()
    {
        // Startwerte für Spielerdaten
        playerData = new PlayerData();
        playerData.coins = 0;

       playerData.levelProgressList = new List<LevelData>();

        // Setze Level-Progress-Daten für Level 1-4
        for (int i = 1; i <= 4; i++)
        {
            LevelData levelData = new LevelData();
            levelData.levelIndex = i;
            levelData.isCompleted = false;
            playerData.levelProgressList.Add(levelData);
        }
    }

    // Speichern von Sternen für ein bestimmtes Level
    public void SaveStars(int levelIndex, bool[] starArray)
    {
         if (levelIndex >= 1 && levelIndex <= playerData.levelProgressList.Count)
        {
            LevelData levelData = playerData.levelProgressList[levelIndex - 1];

            // Konvertiere das bool-Array in einen JSON-String
            string jsonStars = JsonUtility.ToJson(starArray);
            // Speichere den JSON-String in PlayerPrefs
            PlayerPrefs.SetString("Stars" + levelIndex, jsonStars);
        }
    }

    // Laden von Sternen für ein bestimmtes Level
    public int LoadStars(int levelIndex)
    {
        return PlayerPrefs.GetInt("Stars" + levelIndex, 0);
    }

  public void SaveLevelCompletion(int levelIndex, bool isCompleted)
    {
        if (levelIndex >= 1 && levelIndex <= playerData.levelProgressList.Count)
        {
            playerData.levelProgressList[levelIndex - 1].isCompleted = isCompleted;
        }
    }

    // Laden von Levelabschlussstatus
    public bool LoadLevelCompletion(int levelIndex)
    {
        if (levelIndex >= 1 && levelIndex <= playerData.levelProgressList.Count)
        {
            return playerData.levelProgressList[levelIndex - 1].isCompleted;
        }

        return false;
    }

    // Speichern von Münzen
    public void SaveCoins(int coins)
    {
        PlayerPrefs.SetInt("Coins", coins);
    playerData.coins = coins;
    }

    // Laden von Münzen
    public int LoadCoins()
    {
        return PlayerPrefs.GetInt("Coins", 0);
    }
}
