using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Die maximale Gesundheit des Spielers.
    public int currentHealth;    // Die aktuelle Gesundheit des Spielers.
    public GameObject[] objectsToAppear;

    private void Start()
    {
        currentHealth = maxHealth; // Setzen Sie die aktuelle Gesundheit zu Beginn auf die maximale Gesundheit.
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

    public void Die()
    {
        Debug.Log("Spieler ist gestorben!");
        // Objekte erscheinen lassen
        foreach (GameObject obj in objectsToAppear)
        {
            obj.SetActive(true); // Objekt aktivieren, damit es sichtbar wird
        }
    }

    public void SetFullHealth()
    {
        currentHealth = maxHealth;
    }

}
