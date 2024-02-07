using UnityEngine;
using System.Collections;

public class Boss_Entrance : MonoBehaviour
{
    public Transform newSpawnpoint; // Der neue Spawnpoint, an dem der Spieler erscheinen soll
    public AudioClip newMusic; // Die neue Musik, die abgespielt werden soll
    private bool musicChanged = false; // Überprüfen, ob die Musik bereits geändert wurde


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = newSpawnpoint.position;
            // Finde die Kamera im Spiel
            GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            if (mainCamera != null)
            {
                AudioSource audioSource = mainCamera.GetComponent<AudioSource>();
                if (audioSource != null && newMusic != null)
                {
                    audioSource.Stop(); // Stoppe die aktuelle Musik
                    audioSource.clip = newMusic; // Setze die neue Musik
                    audioSource.Play(); // Spiele die neue Musik ab
                    musicChanged = true; // Markiere, dass die Musik bereits geändert wurde
                }
            }
        }
    }
    /*
    bool BossEnemyDestroyed()
    {
        // Überprüfe, ob der Boss zerstört wurden
        if (boss != null && boss.activeSelf)
        {
            return false;
        }
    return true; // Alle Gegner wurden zerstört
    }
    */
}
