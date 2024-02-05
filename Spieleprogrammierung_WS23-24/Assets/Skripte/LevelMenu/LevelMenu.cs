using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class LevelMenu : MonoBehaviour
{
   public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
     public GameObject Lock1;   
 public GameObject Lock2; 
  public GameObject Complete1; 
   public GameObject Complete2; 
    public GameObject Complete3; 
     public TMP_Text coinString1;
      public TMP_Text coinString2;
       public TMP_Text coinString3;

 void Start(){
      enableLevel();
 }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Return) && Level1.activeSelf)
    {
      SceneManager.LoadScene("Tutorial");
    } 
    else if (Input.GetKeyDown(KeyCode.Return) && Level2.activeSelf)
    {
        if ( !Lock1.activeSelf){
            SceneManager.LoadScene("Level 1");
        }
   
    } 
     else if (Input.GetKeyDown(KeyCode.Return) && Level3.activeSelf)
    {
         if ( !Lock2.activeSelf){
            SceneManager.LoadScene("Level 2");
        }
    } 

    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("level1UI"))
        {
            Level1.SetActive(true);
             coinString1.text = LevelManager.GetCollectedCoins(LevelManager.LevelID.Level1).ToString() + "/25";
        }
        else if (collision.CompareTag("level2UI"))
        {
            Level2.SetActive(true);
            coinString2.text = LevelManager.GetCollectedCoins(LevelManager.LevelID.Level2).ToString()+ "/25";
        }
         else if (collision.CompareTag("level3UI"))
        {
            Level3.SetActive(true);
             coinString3.text = LevelManager.GetCollectedCoins(LevelManager.LevelID.Level3).ToString() + "/25";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("level1UI"))
        {
           Level1.SetActive(false);
        }
        else if (collision.CompareTag("level2UI"))
        {
           Level2.SetActive(false);
        }
         else if (collision.CompareTag("level3UI"))
        {
           Level3.SetActive(false);
        }
    }


    void enableLevel()
{
    // Überprüfe, ob Level 1 abgeschlossen ist
    if (LevelManager.IsLevelCompleted(LevelManager.LevelID.Level1))
    {
        Lock1.SetActive(false);
        Complete1.SetActive(true);
    }

    // Überprüfe, ob sowohl Level 1 als auch Level 2 abgeschlossen sind
    if (LevelManager.IsLevelCompleted(LevelManager.LevelID.Level1) && 
        LevelManager.IsLevelCompleted(LevelManager.LevelID.Level2))
    {
        Lock2.SetActive(false);
         Complete2.SetActive(true);
    }
    if (LevelManager.IsLevelCompleted(LevelManager.LevelID.Level3)) 
    {
        
         Complete3.SetActive(true);
    }
}
}
