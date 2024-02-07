using System.Collections;
using UnityEngine;

public class AnimationDelay : MonoBehaviour
{
    public Animator animator;
    public float animationInterval = 4.0f; // Zeitintervall zwischen den Animationen in Sekunden

    private void Start()
    {
        // Starten Sie die Coroutine zum Abspielen der Animationen in regelmäßigen Abständen
        StartCoroutine(PlayAnimationEveryInterval());
    }

    IEnumerator PlayAnimationEveryInterval()
    {
        while (true) // Endlosschleife, um die Animationen kontinuierlich abzuspielen
        {
            // Spielen Sie die Animation ab
            animator.SetTrigger("PlayAnimation");

            // Warten Sie für das angegebene Zeitintervall, bevor die nächste Animation abgespielt wird
            yield return new WaitForSeconds(animationInterval);
        }
    }
}

