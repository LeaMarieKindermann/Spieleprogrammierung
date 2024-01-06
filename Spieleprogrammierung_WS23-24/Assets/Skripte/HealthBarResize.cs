using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarResize : MonoBehaviour
{
    public RectTransform healthBarRectTransform; // Ziehen Sie die RectTransform-Komponente Ihres Health Bar-Images hier hin.
    public PlayerHealth playerHealth; // Ziehen Sie hier die PlayerHealth-Komponente hin, um den aktuellen HP-Wert abzurufen.

    // Ursprüngliche Breite des Health Bar-Images speichern.
    private float originalWidth;

    void Start()
    {
        originalWidth = healthBarRectTransform.sizeDelta.x;
    }

    void Update()
    {
        float healthPercentage = (float)playerHealth.currentHealth / playerHealth.maxHealth;
        float newWidth = originalWidth * healthPercentage;

        Vector2 newSize = new Vector2(newWidth, healthBarRectTransform.sizeDelta.y);
        healthBarRectTransform.sizeDelta = newSize;
    }
}
