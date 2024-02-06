using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
     public CollectManager managerCoin;
    public  CollectStarManager managerStar;
    public AudioSource coinAudio;
     public AudioSource starAudio;

   
     void Update()
     {
        
     }

      private void OnTriggerEnter2D(Collider2D other)
     {
          if (other.CompareTag("star1"))
          {
            starAudio.Play();
             managerStar.AddStar( 0);
              Destroy(other.gameObject);
          }
           else if (other.CompareTag("star2"))
          {
             starAudio.Play();
              managerStar.AddStar( 1);
              Destroy(other.gameObject);
          }
           else if (other.CompareTag("star3"))
          {
             starAudio.Play();
              managerStar.AddStar( 2);
              Destroy(other.gameObject);
          }
        else  if (other.CompareTag("coin"))
         {
          coinAudio.Play();
              managerCoin.AddCoin();
             Destroy(other.gameObject);
         }
     }
}
