using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretRoomController : MonoBehaviour
{
    public GameObject secretRoom; // Referenz auf den Secret Room

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            secretRoom.SetActive(false);
        }
    }

}
