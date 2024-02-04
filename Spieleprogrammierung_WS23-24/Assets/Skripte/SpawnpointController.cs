using UnityEngine;

public class SpawnpointController : MonoBehaviour
{
    public Transform newSpawnpoint; // Der neue Spawnpoint, an dem der Spieler erscheinen soll

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Teleportiere den Spieler zum neuen Spawnpoint
            collision.transform.position = newSpawnpoint.position;
        }
    }
}
