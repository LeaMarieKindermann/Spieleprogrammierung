/* using UnityEngine;
using System.Collections;

public class ParkourController : MonoBehaviour
{
    public GameObject[] parkourObjects; // Eine Liste der Objekte im Parkour
    public float activationDuration = 2f; // Die Dauer, für die jedes Objekt aktiviert sein soll
    public float timeBetweenObjects = 1f; // Die Wartezeit zwischen der Aktivierung verschiedener Objekte
    public float timeBetweenLoops = 5f; // Die Wartezeit zwischen den Durchläufen des Parkours

    void Start()
    {
        StartCoroutine(RunParkour());
    }

    IEnumerator RunParkour()
    {
        while (true)
        {
            // Iteriere über jedes Objekt im Parkour
            foreach (GameObject obj in parkourObjects)
            {
                // Aktiviere das aktuelle Objekt
                //obj.SetActive(true);

                // Warte für die Aktivierungsdauer
                //float timer = 0f;
                //while (timer < activationDuration)
                //{
                    //timer += Time.deltaTime;
                    //yield return null;
                //}

                // Deaktiviere das aktuelle Objekt
                obj.SetActive(false);

                // Wartezeit zwischen den Objekten
                // yield return new WaitForSeconds(timeBetweenObjects);
            }

            // Wartezeit zwischen den Durchläufen des Parkours
            // yield return new WaitForSeconds(timeBetweenLoops);
        }
    }
}
*/