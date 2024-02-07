using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 10; // Die maximale Gesundheit der Fledermaus
    public int currentHealth;    // Die aktuelle Gesundheit der Fledermaus
    public Animator bossAnimator; // Der Animator für die Animationen der Fledermaus
    private bool isDead = false;


    void Start()
    {
        currentHealth = maxHealth; // aktuelle Gesundheit zu Beginn auf die maximale Gesundheit setzen
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // Überprüfen Sie, ob die aktuelle Gesundheit kleiner oder gleich Null ist.
        if (currentHealth <= 0)
        {
            isDead = true;
            Die();
        }
    }

    public bool IsDead()
    {
        return isDead; // Gib den Wert von isDead zurück, um anderen Skripten mitzuteilen, ob die Spinne tot ist oder nicht
    }

    void Die()
    {

        Debug.Log("Boss ist gestorben!");
        // Sterbeanimation der Fledermaus
        bossAnimator.SetTrigger("die"); 

        StartCoroutine(DestroyAfterAnimation(2f));
    }

    IEnumerator DestroyAfterAnimation(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Objekt aus der Szene löschen
        Destroy(gameObject);
    }
}
