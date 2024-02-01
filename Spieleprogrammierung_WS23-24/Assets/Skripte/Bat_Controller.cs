using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_Controller : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 2;
    public float aggroRadius = 5f;
    public float attackCooldownTime = 3f;

    private Animator batAnimator;
    private Rigidbody2D batRigidbody;
    private Transform player;
    private bool canAttack = true;
    private float attackCooldown;
    public string batID;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        batAnimator = GetComponent<Animator>();
        batRigidbody = GetComponent<Rigidbody2D>();
        // Cooldown auf die Startzeit setzen
        attackCooldown = attackCooldownTime; 
    }

    void Update()
    {
        // Überprüfen Sie zuerst, ob der Spieler innerhalb des Aggro-Radius ist.
        if (Vector2.Distance(transform.position, player.position) <= aggroRadius)
        {
            // abspielen der Flug-Animation der Fledermaus
            batAnimator.SetTrigger("Fly");
            // Fledermaus bewegt sich in Richtung des Spielers
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            // Überprüfung, ob Fledermaus den Spieler erreicht hat
            if (Vector2.Distance(transform.position, player.position) < 1f && canAttack)
            {
                batAnimator.SetTrigger("Attack");
                AttackPlayer(player);
                canAttack = false; // canAttack auf false, damit die Fledermaus nicht sofort wieder angreift
                attackCooldown = attackCooldownTime; // Cooldown neu setzen
            }
        }

        // Überprüfen und aktualisieren Sie den Cooldown-Timer.
        if (!canAttack)
        {
            attackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0)
            {
                canAttack = true; // Die Fledermaus kann erneut angreifen.
            }
        }
    }

    void AttackPlayer(Transform target)
    {
        // Hier können Sie weitere Logik hinzufügen, z. B. Animation, Sound usw.
        //batAnimator.SetTrigger("Attack");
        Debug.Log("Fledermaus greift den Spieler an und verursacht " + damage + " Schaden!");

        // Fügen Sie dem Spieler Schaden hinzu.
        // Sie müssen eine Referenz zum Spieler-Skript haben, um ihm Schaden zuzufügen.
        target.GetComponent<PlayerHealth>().TakeDamage(damage);
    }

    void Die()
    {
        Debug.Log("Fledermaus ist gestorben!");
        // Sterbeanimation der Fledermaus
        batAnimator.SetTrigger("Die"); 

        // Deaktiviere die Rigidbody2D-Komponente, um die gravitationsbedingte Bewegung zu stoppen
        batRigidbody.simulated = false;

        StartCoroutine(DestroyAfterAnimation(2f));
    }

    IEnumerator DestroyAfterAnimation(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Objekt aus der Szene löschen
        Destroy(gameObject);
    }
}
