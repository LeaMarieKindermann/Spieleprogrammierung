using UnityEngine;

public class DungeonEntrance : MonoBehaviour
{
    public Transform dungeonSpawnPoint; // Der Punkt, an dem der Spieler nach dem Betreten des Dungeons spawnen soll
    public Transform dungeonCameraPoint; // Der Punkt, an dem die Kamera nach dem Betreten des Dungeons positioniert werden soll
    public GameObject player; // Eine Referenz auf das Spielerobjekt
    public Camera mainCamera; // Eine Referenz auf die Hauptkamera

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Teleportiere den Spieler zum Spawnpoint des Dungeons
            player.transform.position = dungeonSpawnPoint.position;

            // Positioniere die Kamera an den entsprechenden Punkt
            mainCamera.transform.position = dungeonCameraPoint.position;
            mainCamera.transform.rotation = dungeonCameraPoint.rotation;
        }
    }
}
