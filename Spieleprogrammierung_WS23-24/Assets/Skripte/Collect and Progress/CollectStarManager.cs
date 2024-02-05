using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectStarManager : MonoBehaviour
{
    public LevelManager.LevelID levelID;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;



  
  void Start()
    {
        star1.SetActive(false);
        
        star2.SetActive(false);

        star3.SetActive(false);
                    
        UpdateStarUI(); 
    }

      public void AddStar( int starNumber)
     {
        
        LevelManager.SaveCollectedStar(levelID, starNumber);
        UpdateStarUI();
        
    }

    private void UpdateStarUI()
     {
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
