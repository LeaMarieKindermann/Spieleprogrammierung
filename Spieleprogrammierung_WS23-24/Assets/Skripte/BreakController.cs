using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BreakController : MonoBehaviour
{
     public GameObject Break;

    void Start()
    {
         Break.SetActive(false);
    }

    void Update()
{
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        
        showBreak();
    }
}

    public void showBreak()
    {
  
        Break.SetActive(true);
    }

    public void closeBreak()
    {
       
        Break.SetActive(false);
    }

    public void startOver()
{
     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

public void toLevelMenu()
{
   
     SceneManager.LoadScene("Level-Menu");
}

public void toHomeMenu()
{
   
    SceneManager.LoadScene("Main-Menu 1");
}
}
