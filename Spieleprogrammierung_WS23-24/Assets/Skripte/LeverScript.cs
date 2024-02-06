using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public GameObject[] objectsToAppear; // Referenz auf die Objekte, die erscheinen sollen

    private bool leverActivated = false; // Flag, um zu überprüfen, ob der Hebel betätigt wurde
    private Animator leverAnimator;
      public AudioSource leverAudio;

    void Start()
    {
        leverAnimator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !leverActivated)
        {
            leverAudio.Play();
            leverActivated = true; // Der Hebel wurde betätigt
            leverAnimator.SetTrigger("pushed");

            // Objekte erscheinen lassen
            foreach (GameObject obj in objectsToAppear)
            {
                obj.SetActive(true); // Objekt aktivieren, damit es sichtbar wird
            }
        }
    }
}
