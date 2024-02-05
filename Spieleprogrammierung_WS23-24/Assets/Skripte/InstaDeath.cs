using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaDeath : MonoBehaviour
{

    public PlayerHealth playerhealth;

    void OnCollisionEnter2D(Collision2D collision)
    {
        playerhealth.Die();
    }
}
