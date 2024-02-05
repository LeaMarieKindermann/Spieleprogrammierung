using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectManager : MonoBehaviour
{
    public int coin;
    public TMP_Text coinString;
   

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
       coinString.text = coin.ToString();
    }
    public void AddCoin(){
        coin++;
    }

    
}
