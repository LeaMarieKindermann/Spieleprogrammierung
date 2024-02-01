using UnityEngine;

public class SecretRoom_Fight : MonoBehaviour
{
    public float initialDelay = 0f; // Verzögerung vor der ersten Aktivierung
    public float activationCooldown = 8f; // Cooldown zwischen den Aktivierungen

    private void Start()
    {
        // Deaktiviere den Gegner zu Beginn
        gameObject.SetActive(false);

        // Starte den Cooldown für die Aktivierung
        Invoke("ActivateEnemy", initialDelay);
    }

    private void ActivateEnemy()
    {
        // Aktiviere den Gegner
        gameObject.SetActive(true);

        // Starte den Cooldown für die nächste Aktivierung
        Invoke("ActivateEnemy", activationCooldown);
    }
}
