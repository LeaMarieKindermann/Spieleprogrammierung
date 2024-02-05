using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu; 
    public GameObject Settings;

    public void toLevelMenu()
    {
        SceneManager.LoadScene("Level-Menu");
    }

     public void openSettings()
    {
       
         Menu.SetActive(false);

      
       Settings.SetActive(true);
    }

    public void endGame()
    {
        Application.Quit(); 
    }

 public void deleteGameProgress()
    {
    PlayerPrefs.DeleteAll();
    closeSettings();
    }

      public void closeSettings()
    {
       Settings.SetActive(false);
         Menu.SetActive(true);
       
    }
}
