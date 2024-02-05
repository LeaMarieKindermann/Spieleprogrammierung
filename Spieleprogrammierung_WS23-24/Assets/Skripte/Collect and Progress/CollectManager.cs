using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectManager : MonoBehaviour
{

   public LevelManager.LevelID levelID; 
     public TMP_Text coinString;
   


     void Start()
   {
    // Münzen zum start auf 0  setzen
    LevelManager.SaveCollectedCoins(levelID, 0);
      UpdateCoinText();
    }

     public void AddCoin(){
        LevelManager.SaveCollectedCoins(levelID, LevelManager.GetCollectedCoins(levelID) + 1);
        UpdateCoinText();
     }


     private void UpdateCoinText()
     {
         coinString.text = LevelManager.GetCollectedCoins(levelID).ToString() + "/25";
     }

       private void SaveCoins(int coins)
    {
       LevelManager.SaveCollectedCoins(levelID, coins);
        
    }
    
}
