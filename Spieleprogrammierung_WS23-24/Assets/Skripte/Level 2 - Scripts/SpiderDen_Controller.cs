using UnityEngine;

public class SpiderDen_Controller : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Die Objekte, die gespawnt werden sollen
    public float aggroRadius = 5f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Überprüfen Sie zuerst, ob der Spieler innerhalb des Aggro-Radius ist.
        if (Vector2.Distance(transform.position, player.position) <= aggroRadius)
        {
            SpawnObjects();
        }
    }


    void SpawnObjects()
    {

        foreach (GameObject obj in objectsToSpawn)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
        
    }
}
