using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesAlgorithm : MonoBehaviour
{
    public GameObject[] parkourObjects; // Array der Objekte im Parkour
    public float boxActiveDuration = 3f; // Dauer, für die jede Box aktiv bleibt
    public float timeBetweenBoxes = 1f; // Verzögerung zwischen den Boxen

    private int currentIndex = 0; // Index des aktuellen Objekts

    void Start()
    {
        // Starte die Aktivierungsroutine
        StartCoroutine(ActivateObjects());
    }

    IEnumerator ActivateObjects()
    {
        while (true) // Dauerhaft wiederholen
        {
            foreach (GameObject obj in parkourObjects)
            {
                obj.SetActive(false); // Deaktiviere alle Objekte zu Beginn
            }

            currentIndex = 0; // Setze den Index zurück

            while (currentIndex < parkourObjects.Length)
            {
                // Aktiviere das aktuelle Objekt
                parkourObjects[currentIndex].SetActive(true);

                // Warte für die Dauer, die die Box aktiv bleiben soll
                yield return new WaitForSeconds(boxActiveDuration);

                // Deaktiviere das aktuelle Objekt
                parkourObjects[currentIndex].SetActive(false);

                // Inkrementiere den Index für das nächste Objekt
                currentIndex++;

                // Warte für die Verzögerung zwischen den Boxen, wenn es noch eine gibt
                if (currentIndex < parkourObjects.Length)
                {
                    yield return new WaitForSeconds(timeBetweenBoxes);
                }
            }
        }
    }

}
