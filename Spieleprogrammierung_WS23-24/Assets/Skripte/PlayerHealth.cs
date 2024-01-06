using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Die maximale Gesundheit des Spielers.
    public int currentHealth;    // Die aktuelle Gesundheit des Spielers.

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

    void Die()
    {
        // Hier können Sie Logik für den Tod des Spielers hinzufügen, z. B. Spiel neu starten.
        Debug.Log("Spieler ist gestorben!");
        // Zum Beispiel: SceneManager.LoadScene("GameOverScene");
    }

}
