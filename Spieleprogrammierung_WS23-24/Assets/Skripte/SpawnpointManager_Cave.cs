using UnityEngine;

public class SpawnpointManager_Cave : MonoBehaviour
{
    private Vector3 spawnpointPosition; // Die Position des Spawnpoints

    void Start()
    {
        // Speichere die Position des Spawnpoints beim Start
        spawnpointPosition = transform.position;
    }

    public Vector3 GetSpawnpointPosition()
    {
        return spawnpointPosition; // Gib die Position des Spawnpoints zurück
    }
}
