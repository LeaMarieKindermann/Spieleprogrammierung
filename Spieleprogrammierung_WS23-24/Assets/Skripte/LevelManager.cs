using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<LevelData> levels = new List<LevelData>();

    void Start()
    {
        // Initialisiere Level-Daten
        InitializeLevelData();
    }

   void InitializeLevelData()
{
    for (int i = 1; i <= 3; i++)
    {
        LevelData levelData = new LevelData();
        levelData.levelIndex = i;
        levelData.starArray = new bool[3];
        //levelData.starsNeeded = PlayerProgress.instance.LoadStars(i);
        levels.Add(levelData);
    }
}

}

[System.Serializable]
public class LevelData
{
    public int levelIndex;
    public bool[] starArray;
     public bool isCompleted;
}

