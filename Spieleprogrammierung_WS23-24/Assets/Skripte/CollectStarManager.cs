using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CollectStarManager : MonoBehaviour
{
     public int star;
    public TMP_Text starString;
    // Start is called before the first frame update
    void Start()
    {
           star = PlayerPrefs.GetInt("starString", 0);
    }

    // Update is called once per frame
    void Update()
    {
        starString.text =PlayerPrefs.GetInt("starString", 0).ToString();
    }
     public void AddStar(){
        star++;
        PlayerPrefs.SetInt("starString", star);
    }
}
