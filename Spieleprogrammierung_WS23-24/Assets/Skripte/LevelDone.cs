using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelDone : MonoBehaviour
{
     LevelManager.LevelID levelID;
     public TMP_Text coinString;

  void Start()
{
    string levelIDString = PlayerPrefs.GetString("CurrentLevelID", "");
    
    if (!string.IsNullOrEmpty(levelIDString))
    {
      
     levelID = (LevelManager.LevelID)System.Enum.Parse(typeof(LevelManager.LevelID), levelIDString);
     Debug.Log("levelID " + levelID);
     Debug.Log("LevelManager.GetCollectedCoins(levelID) " + LevelManager.GetCollectedCoins(levelID));
      coinString.text = LevelManager.GetCollectedCoins(levelID).ToString() + "/25";
    }
   
    
}
  
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.Return))
    {
       PlayerPrefs.DeleteKey("CurrentLevelID");
      SceneManager.LoadScene("Level-Menu");
    } 
    }
}
