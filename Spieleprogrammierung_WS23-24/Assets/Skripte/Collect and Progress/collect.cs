using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
     public CollectManager managerCoin;
    public  CollectStarManager managerStar;
   

   
     void Update()
     {
        
     }

      private void OnTriggerEnter2D(Collider2D other)
     {
          if (other.CompareTag("star1"))
          {
             managerStar.AddStar( 0);
              Destroy(other.gameObject);
          }
           else if (other.CompareTag("star2"))
          {
              managerStar.AddStar( 1);
              Destroy(other.gameObject);
          }
           else if (other.CompareTag("star3"))
          {
              managerStar.AddStar( 2);
              Destroy(other.gameObject);
          }
        else  if (other.CompareTag("coin"))
         {
          
              managerCoin.AddCoin();
             Destroy(other.gameObject);
         }
     }
}
