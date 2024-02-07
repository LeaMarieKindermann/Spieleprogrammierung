using System.Collections;
using UnityEngine;

public class Boss_Controller : MonoBehaviour
{
    public Transform player; // Referenz auf den Spieler
    public float dashSpeed = 10f; // Geschwindigkeit des Dashs
    public float attackDuration = 4f; // Dauer der Angriffsanimation
    public float attackCooldown = 3f; // Abklingzeit zwischen den Angriffen
    private bool isAttacking = false; // Gibt an, ob der Endboss gerade angreift
    public Animator bossAnimator;
    private Vector3 currentScale;
    private Transform objectTransform;
    public BoxCollider2D weaponHitbox;
    private Vector3 originalPositionWeapon;
    public int damage = 5;

    void Start()
    {
        objectTransform = transform;

        // Aktuelle Skalierung des Objekts
        currentScale = objectTransform.localScale;
        // Speichere die Originalposition der Hitbox
        originalPositionWeapon = weaponHitbox.transform.position;

        // weaponHitbox.enabled = false;
        bossAnimator = GetComponent<Animator>();
        StartCoroutine(AttackPattern());
        weaponHitbox.enabled = false;
    }

    IEnumerator AttackPattern()
    {
        while (true) // Dauerhaft wiederholen
        {
            yield return new WaitForSeconds(attackCooldown);

            // Führe den Dash aus
            yield return StartCoroutine(Dash()); // Warte, bis der Dash beendet ist

            // Führe den Angriff aus
            yield return StartCoroutine(Attack()); // Warte, bis der Angriff beendet ist

            // Warte, bis der Angriff beendet ist
            bossAnimator.SetTrigger("stun");
            weaponHitbox.enabled = false;
            yield return new WaitForSeconds(2f); // Wartezeit nach dem Angriff
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.gameObject.CompareTag("Player")) {
        Debug.Log("Player hit");
        player.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
    }

    IEnumerator Dash()
    {
        weaponHitbox.enabled = true;
        bossAnimator.SetTrigger("dash");
        // Richtung zum Spieler berechnen
        Vector3 direction = (player.position - transform.position).normalized;

        // Führe den Dash aus, indem du dich in Richtung des Spielers bewegst
        while (Vector3.Distance(transform.position, player.position) > 3f)
        {
            transform.position += direction * dashSpeed * Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator Attack()
    {
        // Führe hier die Angriffsanimation aus
        bossAnimator.SetTrigger("attack");
        Debug.Log("Angriff ausgeführt!");

        // Starte die Drehung während des Angriffs
        StartCoroutine(AlternateTurn());

        // Warte für die Dauer der Angriffsanimation
        yield return new WaitForSeconds(attackDuration);
    }

    IEnumerator AlternateTurn()
    {
        // Setze die Skalierung auf x = -1.3
        objectTransform.localScale = new Vector3(1.3f, currentScale.y, currentScale.z);
        yield return new WaitForSeconds(2f);
        // Setze die Skalierung zurück
        objectTransform.localScale = currentScale;
    
    }
    /*
    void EnableHitbox()
    {
        ActivateHitboxWithDelay();
    }

    void AttackPlayer()
    {
        Debug.Log("Spieler greift Gegner an und verursacht " + damage + " Schaden!");
        player.GetComponent<PlayerHealth>().TakeDamage(damage);
    }

    void ActivateHitboxWithDelay()
    {
        // Debug.Log("Hitbox activated!");
        weaponHitbox.enabled = true;
        Invoke("DeactivateHitbox", 0.5f); 
    }


    void DeactivateHitbox()
    {
        // Debug.Log("Hitbox deactivated!");
        weaponHitbox.enabled = false;
    } 
*/
}
