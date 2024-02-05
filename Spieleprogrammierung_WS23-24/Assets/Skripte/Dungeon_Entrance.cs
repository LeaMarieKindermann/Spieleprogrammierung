using UnityEngine;
using System.Collections;

public class Dungeon_Entrance : MonoBehaviour
{
    public Transform newSpawnpoint; // Der neue Spawnpoint, an dem der Spieler erscheinen soll
    public GameObject[] enemies; // Array der Gegner-Objekte, die im Inspector gezogen werden
    public GameObject exitObject; // Das Ausgangsobjekt, das erscheinen soll, wenn alle Gegner zerstört wurden
    public float spawnInterval = 7f; // Das Intervall zwischen den Spawns

    private bool spawningEnabled = false; // Variable, um das Spawnen der Gegner zu aktivieren/deaktivieren

    void Start()
    {
        // Deaktiviere das Spawnen der Gegner am Anfang
        spawningEnabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = newSpawnpoint.position;
            // Aktiviere das Spawnen der Gegner, wenn der Spieler den Collider berührt
            spawningEnabled = true;
            // Starte die Coroutine zum Spawnen der Gegner
            StartCoroutine(SpawnEnemies());
        }
    }

    IEnumerator SpawnEnemies()
{
    foreach (GameObject enemy in enemies)
    {
        // Überprüfe, ob der Gegner existiert und nicht bereits zerstört wurde
        if (enemy != null)
        {
            // Aktiviere den Gegner, wenn er nicht bereits aktiv ist
            if (!enemy.activeSelf)
            {
                enemy.SetActive(true);
            }
        }
        yield return new WaitForSeconds(spawnInterval);
    }

    // Überprüfe, ob alle Gegner zerstört wurden
    while (!AllEnemiesDestroyed())
    {
        yield return null;
    }

    // Alle Gegner wurden zerstört, zeige den Ausgang an
    if (exitObject != null)
    {
        exitObject.SetActive(true);
    }
}


    bool AllEnemiesDestroyed()
    {
        // Überprüfe, ob alle Gegner zerstört wurden
        foreach (GameObject enemy in enemies)
        {
            // Wenn ein Gegner noch aktiv ist, ist nicht jeder zerstört
            if (enemy != null && enemy.activeSelf)
            {
                return false;
            }
        }
        return true; // Alle Gegner wurden zerstört
    }
}
