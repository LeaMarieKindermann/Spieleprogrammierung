using UnityEngine;

public class Spikes : MonoBehaviour
{
    public int damage = 2; // Menge des Schadens, den das Objekt verursacht
    public float damageInterval = 3f; // Zeitintervall zwischen den Schadensanrichtungen
    private float timer; // Timer für die Schadensintervalle

    void Start()
    {
        timer = 0f; // Initialisiere den Timer
    }

    void Update()
    {
        // Timer aktualisieren
        timer += Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Überprüfe, ob das kollidierende Objekt den Spieler-Tag hat
        if (collision.gameObject.CompareTag("Player"))
        {
            // Spieler steht auf den Spikes, starte den Timer
            if (timer >= damageInterval)
            {
                ApplyDamage(collision.gameObject);
                timer = 0f; // Setze den Timer zurück
            }
        }
    }

    void ApplyDamage(GameObject player)
    {
        Debug.Log("Spikes machen " + damage + " Schaden!");
        player.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
}
