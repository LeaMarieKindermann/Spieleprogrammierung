using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    private CollectManager managerCoin;
     private CollectStarManager managerStar;
      public int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        managerCoin = GameObject.FindGameObjectWithTag("coinText").GetComponent<CollectManager>();
        managerStar = GameObject.FindGameObjectWithTag("starText").GetComponent<CollectStarManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
         if (other.CompareTag("star1"))
         {
             managerStar.AddStar(currentLevel, 0);
             Destroy(other.gameObject);
         }
          else if (other.CompareTag("star2"))
         {
             managerStar.AddStar(currentLevel, 1);
             Destroy(other.gameObject);
         }
          else if (other.CompareTag("star3"))
         {
             managerStar.AddStar(currentLevel, 2);
             Destroy(other.gameObject);
         }
       else if (other.CompareTag("coin"))
        {
             managerCoin.AddCoin();
            Destroy(other.gameObject);
        }
    }
}
