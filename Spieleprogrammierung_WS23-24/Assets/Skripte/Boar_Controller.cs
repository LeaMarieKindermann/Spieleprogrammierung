using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectMovement : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 5f;
    public float moveSpeed = 3f;

    private bool isMoving = false;

    void Start()
    {
        // Starte die Coroutine für die Objektbewegung
        StartCoroutine(ObjectMovementCoroutine());
    }

    IEnumerator ObjectMovementCoroutine()
    {
        while (true)
        {
            // Prüfe, ob der Spieler in Reichweite ist
            if (Vector3.Distance(transform.position, player.position) <= detectionRange)
            {
                isMoving = true;
                // Bewege das Objekt für 2 Sekunden
                yield return new WaitForSeconds(2f);
                isMoving = false;
                // Warte 3 Sekunden, bevor die Bewegung wiederholt wird
                yield return new WaitForSeconds(3f);
            }
            else
            {
                yield return null;
            }
        }
    }

    void Update()
    {
        // Wenn das Objekt sich bewegt
        if (isMoving)
        {
            // Bewege das Objekt in Richtung des Spielers
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}
