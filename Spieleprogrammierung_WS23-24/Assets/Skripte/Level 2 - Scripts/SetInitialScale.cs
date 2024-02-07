using UnityEngine;

public class SetInitialScale : MonoBehaviour
{
    void Start()
    {
        // Zugriff auf das Transform-Objekt des aktuellen GameObjects
        Transform objectTransform = transform;

        // Aktuelle Skalierung des Objekts
        Vector3 currentScale = objectTransform.localScale;

        // Setze die Skalierung auf y = -1.3 und behalte die anderen Werte bei
        objectTransform.localScale = new Vector3(currentScale.x, -1.3f, currentScale.z);
    }
}
