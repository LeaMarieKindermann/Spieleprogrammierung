using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTutorials : MonoBehaviour
{
       public GameObject Tutorial1;
    public GameObject Tutorial2;
    public GameObject Tutorial3;
   public GameObject Tutorial4;
   public GameObject Tutorial5;
   public GameObject Tutorial6;
   public GameObject Tutorial7;
   public GameObject Tutorial8;
   public GameObject Tutorial9;
   public GameObject Tutorial10;
   public GameObject Tutorial11;
   

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tutorial1"))
        {
            Tutorial1.SetActive(true);
        }
        else if (collision.CompareTag("Tutorial2"))
        {
            
            Tutorial2.SetActive(true);
        }
        else  if (collision.CompareTag("Tutorial3"))
        {
            Tutorial3.SetActive(true);
        }
        else if (collision.CompareTag("Tutorial4"))
        {
            
            Tutorial4.SetActive(true);
        }
          else if (collision.CompareTag("Tutorial5"))
        {
            
            Tutorial5.SetActive(true);
        }
          else if (collision.CompareTag("Tutorial6"))
        {
            
            Tutorial6.SetActive(true);
        }
          else if (collision.CompareTag("Tutorial7"))
        {
            
            Tutorial7.SetActive(true);
        }
          else if (collision.CompareTag("Tutorial8"))
        {
            
            Tutorial8.SetActive(true);
        }
          else if (collision.CompareTag("Tutorial9"))
        {
            
            Tutorial9.SetActive(true);
        }
           else if (collision.CompareTag("Tutorial10"))
        {
            
            Tutorial10.SetActive(true);
        }
           else if (collision.CompareTag("Tutorial11"))
        {
            
            Tutorial11.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tutorial1"))
        {
           Tutorial1.SetActive(false);
        }
        else if (collision.CompareTag("Tutorial2"))
        {
           Tutorial2.SetActive(false);
        }
         else if (collision.CompareTag("Tutorial3"))
        {
           Tutorial3.SetActive(false);
        }
         else if (collision.CompareTag("Tutorial4"))
        {
           Tutorial4.SetActive(false);
        }
         else if (collision.CompareTag("Tutorial5"))
        {
           Tutorial5.SetActive(false);
        }
         else if (collision.CompareTag("Tutorial6"))
        {
           Tutorial6.SetActive(false);
        }
         else if (collision.CompareTag("Tutorial7"))
        {
           Tutorial7.SetActive(false);
        }
         else if (collision.CompareTag("Tutorial8"))
        {
           Tutorial8.SetActive(false);
        }
          else if (collision.CompareTag("Tutorial9"))
        {
           Tutorial9.SetActive(false);
        }
         else if (collision.CompareTag("Tutorial10"))
        {
           Tutorial10.SetActive(false);
        }
         else if (collision.CompareTag("Tutorial11"))
        {
           Tutorial11.SetActive(false);
        }
       
    }
}
