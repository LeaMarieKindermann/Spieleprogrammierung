using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelDone : MonoBehaviour
{
     LevelManager.LevelID levelID;
     public TMP_Text coinString;
         public GameObject star1;
    public GameObject star2;
    public GameObject star3;

  void Start()
{
    string levelIDString = PlayerPrefs.GetString("CurrentLevelID", "");
    
    if (!string.IsNullOrEmpty(levelIDString))
    {
      
     levelID = (LevelManager.LevelID)System.Enum.Parse(typeof(LevelManager.LevelID), levelIDString);

     displayStars();
   
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

   public void  displayStars(){
     bool[] starArry = new bool[3];
         starArry = LevelManager.GetCollectedStars(levelID);
     
        for (int i = 0; i < starArry.Length; i++)
        {
           if (starArry[i]){
            switch (i)
            {
                case 0:
                    star1.SetActive(true);
                    break;
                case 1:
                    star2.SetActive(true);
                    break;
                case 2:
                    star3.SetActive(true);
                    break;
            

                default:
                    Debug.LogWarning("Ungültiger Index im Array.");
                    break;
            }
           }
        }
   }
}
