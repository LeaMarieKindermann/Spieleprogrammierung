using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderHealth : MonoBehaviour
{
    public int maxHealth = 10; // Die maximale Gesundheit der Fledermaus
    public int currentHealth;    // Die aktuelle Gesundheit der Fledermaus
    public Animator spiderAnimator; // Der Animator für die Animationen der Fledermaus

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
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Spinne ist gestorben!");
        // Sterbeanimation der Fledermaus
        spiderAnimator.SetTrigger("die"); 

        StartCoroutine(DestroyAfterAnimation(2f));
    }

    IEnumerator DestroyAfterAnimation(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Objekt aus der Szene löschen
        Destroy(gameObject);
    }
}
