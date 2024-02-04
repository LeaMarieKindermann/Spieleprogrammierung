using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretRoomController : MonoBehaviour
{
    public GameObject[] secretRoom; // Referenz auf den Secret Room
    private Renderer objRenderer; // Referenz auf die Renderer-Komponente des Objekts

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Überprüfe die Sichtbarkeit für jedes Objekt im secretRoom-Array
            foreach (GameObject obj in secretRoom)
            {
                Renderer objRenderer = obj.GetComponent<Renderer>(); // Hol die Renderer-Komponente für das aktuelle GameObject
                if (objRenderer != null && objRenderer.isVisible)
                {
                    obj.SetActive(false); // Deaktiviere das Objekt, wenn es sichtbar ist
                }
                else
                {
                    obj.SetActive(true); // Aktiviere das Objekt, wenn es nicht sichtbar ist oder keine Renderer-Komponente hat
                }
            }
        }
    }

}
