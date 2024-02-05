using UnityEngine;
using System.Collections;

public class Boar_Controller : MonoBehaviour
{
    public Transform player; // Die Position des Spielers
    public float runningSpeed = 5f; // Die Geschwindigkeit, mit der das Wildschwein rennt
    public float waitTime = 3f; // Die Zeit, die das Wildschwein zwischen den Läufen wartet

    private bool isRunning = false; // Variable, um zu verfolgen, ob das Wildschwein gerade rennt

    void Start()
    {
        // Starte die Coroutine, um das Verhalten des Wildschweins zu steuern
        StartCoroutine(RunTowardsPlayer());
    }

    IEnumerator RunTowardsPlayer()
    {
        while (true)
        {
            // Warte für 3 Sekunden, wenn das Wildschwein nicht rennt
            if (!isRunning)
            {
                yield return new WaitForSeconds(waitTime);
            }

            // Bestimme die Richtung, in die das Wildschwein laufen soll
            Vector3 direction = (player.position - transform.position).normalized;

            // Bewege das Wildschwein in Richtung des Spielers
            isRunning = true;
            while (Vector3.Distance(transform.position, player.position) > 1f)
            {
                transform.position += direction * runningSpeed * Time.deltaTime;
                yield return null;
            }

            // Setze isRunning auf false, um anzuzeigen, dass das Wildschwein nicht mehr rennt
            isRunning = false;
        }
    }
}
