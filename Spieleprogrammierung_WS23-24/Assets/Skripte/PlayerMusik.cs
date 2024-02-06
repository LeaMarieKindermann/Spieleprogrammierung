using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMusik : MonoBehaviour
{
      public AudioSource jump;
    public AudioSource walk;
     public AudioSource hit;
   
 void Update()
    {
        PlaySounds();
    }

void PlaySounds()
    {
        if ( Input.GetKeyDown(KeyCode.Space))
        {
           jump.Play();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) ||
                 Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
             walk.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            hit.Play();
        }

        if (!(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) ||
      Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
{
    walk.Stop();
}
       
    }

   


}
