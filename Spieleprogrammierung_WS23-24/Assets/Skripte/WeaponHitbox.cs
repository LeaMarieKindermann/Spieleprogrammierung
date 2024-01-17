using System.Collections;
using UnityEngine;

public class WeaponHitbox : MonoBehaviour
{
    private Collider2D hitboxCollider;

    private void Start()
    {
        hitboxCollider = GetComponent<Collider2D>();
        DeactivateHitbox();
    }

    public void ActivateHitbox()
    {
        hitboxCollider.enabled = true;
        StartCoroutine(DeactivateHitboxAfterDelay(0.1f)); // Deaktiviere die Hitbox nach 0.1 Sekunden
    }

    private IEnumerator DeactivateHitboxAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        DeactivateHitbox();
    }

    public void DeactivateHitbox()
    {
        hitboxCollider.enabled = false;
    }
}
