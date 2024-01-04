using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    private CollectManager managerCoin;
     private CollectStarManager managerStar;
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
        if (other.CompareTag("star"))
        {
            managerStar.AddStar();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("coin"))
        {
             managerCoin.AddCoin();
            Destroy(other.gameObject);
        }
    }
}
