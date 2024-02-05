using UnityEngine;

public class Slime_Controller : MonoBehaviour
{
    public float moveSpeed = 5f; // Geschwindigkeit des Slime
    private bool movingRight = true; // Richtung des Slime
    public Transform leftBoundary; // Linker Bereichsbegrenzer
    public Transform rightBoundary; // Rechter Bereichsbegrenzer
    public float minCollisionY = 0.5f;
    private Animator slimeAnimator;

    void Start()
    {
        slimeAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // Bewegung des Slime nach rechts oder links
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        // Prüfen, ob der Slime die Begrenzungen erreicht hat
        if (movingRight && transform.position.x >= rightBoundary.position.x)
        {
            movingRight = false;
        }
        else if (!movingRight && transform.position.x <= leftBoundary.position.x)
        {
            movingRight = true;
        }
    }

    // Prüfen auf Kollisionen mit Wänden
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Kollision!");
        if (collision.gameObject.CompareTag("Wall"))
        {
            movingRight = !movingRight; // Richtung umkehren
        }

        // Überprüfe, ob der Spieler den Slime berührt hat und die Kollision von oben erfolgt ist
        if (collision.gameObject.CompareTag("Player") && IsPlayerAboveSlime(collision))
        {
            Debug.Log("Kollision mit Spieler und oben!");
            // Hier könntest du die Aktion ausführen, um den Slime zu töten
            KillSlime();
        }
    }

    // Methode, um zu überprüfen, ob der Spieler von oben auf den Slime springt
    private bool IsPlayerAboveSlime(Collision2D collision)
    {
        // Bestimme die Position des Spielers und des Slime
        Vector2 playerPosition = collision.gameObject.transform.position;
        Vector2 slimePosition = transform.position;

        // Überprüfe, ob der Spieler über dem Slime ist (in der Y-Richtung)
        return playerPosition.y >= slimePosition.y;
    }

    // Methode, um den Slime zu töten
    private void KillSlime()
    {
        slimeAnimator.SetTrigger("die"); 
        Destroy(gameObject, 1f); 
    }
}
