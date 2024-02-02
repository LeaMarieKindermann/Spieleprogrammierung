using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectManager : MonoBehaviour
{
    //public int coin;
    public TMP_Text coinString;
   
 private PlayerProgress playerProgress;
    // Start is called before the first frame update
    void Start()
    {
      LoadCoins();
    }

    // Update is called once per frame
    void Update()
    {
        
      // coinString.text = coin.ToString();
    }
    public void AddCoin(){
         PlayerProgress.instance.SaveCoins(PlayerProgress.instance.LoadCoins() + 1);
        UpdateCoinText();
    }
 private void LoadCoins()
    {
        int coins = PlayerProgress.instance.LoadCoins();
        PlayerProgress.instance.SaveCoins(coins);
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        coinString.text = PlayerProgress.instance.LoadCoins().ToString();
    }
    
}
