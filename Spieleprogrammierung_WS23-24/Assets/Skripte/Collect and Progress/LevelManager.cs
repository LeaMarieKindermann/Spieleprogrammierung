using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

   //  Level-IDs
    public enum LevelID
    {
        Level1,
        Level2,
        Level3
    }

    // Funktion zum Speichern des abgeschlossenen Levels
    public static void SaveCompletedLevel(LevelID levelID)
    {
        string key = "CompletedLevel_" + levelID.ToString();
        PlayerPrefs.SetInt(key, 1);
        PlayerPrefs.Save();
    }

    // Funktion zum Überprüfen, ob ein Level abgeschlossen ist
    public static bool IsLevelCompleted(LevelID levelID)
    {
        string key = "CompletedLevel_" + levelID.ToString();
        return PlayerPrefs.HasKey(key) && PlayerPrefs.GetInt(key) == 1;
    }

    // Funktion zum Speichern der gesammelten Münzen in einem Level
    public static void SaveCollectedCoins(LevelID levelID, int collectedCoins)
    {
        string key = "CollectedCoins_" + levelID.ToString();
         int currentCollectedCoins = PlayerPrefs.GetInt(key, 0);
         currentCollectedCoins += collectedCoins;
        PlayerPrefs.SetInt(key, collectedCoins);
        PlayerPrefs.Save();
    }

    

    // Funktion zum Überprüfen, ob alle Münzen in einem Level gesammelt wurden
    public static bool AreAllCoinsCollected(LevelID levelID)
    {
        string key = "CollectedCoins_" + levelID.ToString();
        int collectedCoins = PlayerPrefs.GetInt(key, 0);
        return collectedCoins == 25; 
    }

     // Funktion zum Überprüfen, wie viele Münzen in einem Level gesammelt wurden
    public static int GetCollectedCoins(LevelID levelID)
    {
        string key = "CollectedCoins_" + levelID.ToString();
        int collectedCoins = PlayerPrefs.GetInt(key, 0);
        return collectedCoins; 
    }

    public static void SaveCollectedStar(LevelID levelID, int starNumber){
        string key = "CollectedStar_" + levelID.ToString() + starNumber.ToString();
        PlayerPrefs.SetInt(key, 1);
        PlayerPrefs.Save();

    }

    public static bool[] GetCollectedStars(LevelID levelID){
        bool[] starArry = new bool[3];
        for ( int i = 0; i < starArry.Length; i ++){
            string key = "CollectedStar_" + levelID.ToString() + i.ToString();
           int star =  PlayerPrefs.GetInt(key, 0);

           if( star == 1){
            starArry[i] = true;
           }
           else {
            starArry[i] = false;
           }

        }
        return starArry;

    }

}

