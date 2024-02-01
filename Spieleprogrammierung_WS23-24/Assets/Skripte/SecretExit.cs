using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretExit : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Entrance!");
            SceneManager.LoadScene("Level 1");

            SpawnpointManager_Cave spawnpointManager = FindObjectOfType<SpawnpointManager_Cave>();
            // Platziere den Spieler am Spawnpoint
            if (SpawnpointManager_Cave.instance != null && SpawnpointManager_Cave.instance.spawnpoint != null)
            {
                collision.transform.position = SpawnpointManager_Cave.instance.spawnpoint.position;
            }
        }
    }
}

