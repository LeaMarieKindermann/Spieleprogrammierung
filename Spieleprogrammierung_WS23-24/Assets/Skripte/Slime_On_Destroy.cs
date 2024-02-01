using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_On_Destroy : MonoBehaviour
{
    public GameObject[] objectsToActivate; // Array der Objekte, die aktiviert werden sollen

    void OnDestroy()
    {
        // Aktiviere alle Objekte im Array
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true);
        }
    }
}
