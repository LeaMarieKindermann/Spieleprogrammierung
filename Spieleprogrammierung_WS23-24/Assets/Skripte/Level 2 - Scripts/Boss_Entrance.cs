using UnityEngine;
using System.Collections;

public class Boss_Entrance : MonoBehaviour
{
    public Transform newSpawnpoint; // Der neue Spawnpoint, an dem der Spieler erscheinen soll
    // public GameObject exitObject; // Das Ausgangsobjekt, das erscheinen soll, wenn alle Gegner zerstört wurden
    // public GameObject boss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = newSpawnpoint.position;
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
