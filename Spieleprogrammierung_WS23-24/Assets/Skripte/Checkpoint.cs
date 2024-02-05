using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // HP, auf die der Spieler beim Aktivieren dieses Checkpoints geheilt wird
    public int healAmount = 20;
    public bool activated = false; // Status des Checkpoints
    public GameObject player;
    private Vector3 respawnPosition; // Position des Checkpoints

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !activated)
        {
            Debug.Log("Checkpoint aktiviert!");
            // Heile den Spieler
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            playerHealth.SetFullHealth();

            // Speichere die Position des Checkpoints als Respawn-Position
            respawnPosition = transform.position;

            // Setze den Checkpoint als aktiviert
            activated = true;

        }
    }

    public Vector3 GetRespawnPosition()
    {
        return respawnPosition;
    }
}

