using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spider_Controller : MonoBehaviour
{
    public float speed = 5f; // Die Geschwindigkeit, mit der die Spinne sich bewegt
    public Transform player; // Die Referenz auf den Spieler
    public float aggroRadius = 5f;
    private float attackCooldown;
    public float attackCooldownTime = 3f;
    public int damage = 2;
    private Animator spiderAnimator;
    private bool canAttack = true;
    private bool isDead = false; 
    private SpiderHealth spiderHealth; // Referenz auf das SpiderHealth Skript
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        attackCooldown = attackCooldownTime; 
        spiderAnimator = GetComponent<Animator>();
        attackCooldown = attackCooldownTime; 
        spiderHealth = GetComponent<SpiderHealth>(); // Holen Sie sich das SpiderHealth-Skript
    }

    void Update()
    {
        if (spiderHealth.IsDead()){
            isDead = true;
        }

        // Überprüfen Sie zuerst, ob der Spieler innerhalb des Aggro-Radius ist.
        if (Vector2.Distance(transform.position, player.position) <= aggroRadius)
        {

            spiderAnimator.SetTrigger("run");
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            
            // Überprüfung, ob Fledermaus den Spieler erreicht hat
            if (Vector2.Distance(transform.position, player.position) < 1.5f && canAttack && isDead == false)
            {

                spiderAnimator.SetTrigger("attack");
                AttackPlayer(player);
                canAttack = false;
                spiderAnimator.SetTrigger("idle");
                attackCooldown = attackCooldownTime; // Cooldown neu setzen
            }
        }
        else 
        {
            spiderAnimator.SetTrigger("idle");
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
        Debug.Log("Spinne greift den Spieler an und verursacht " + damage + " Schaden!");

        // Fügen Sie dem Spieler Schaden hinzu.
        // Sie müssen eine Referenz zum Spieler-Skript haben, um ihm Schaden zuzufügen.
        target.GetComponent<PlayerHealth>().TakeDamage(damage);
    }

}

