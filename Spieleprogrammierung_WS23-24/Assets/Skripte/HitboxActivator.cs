using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxActivator : MonoBehaviour
{
    public WeaponHitbox weaponHitbox;

    private void Start()
    {
        weaponHitbox = GetComponent<WeaponHitbox>();
        if (weaponHitbox == null)
        {
            Debug.LogError("WeaponHitbox not found!");
        }
    }

    // Wird im AnimationEvent aufgerufen
    public void ActivateHitboxWithDelay()
    {
        Debug.Log("Hitbox activated!");
        weaponHitbox.ActivateHitbox();
        Invoke("DeactivateHitbox", 0.2f); // Deaktiviere die Hitbox nach 0.1 Sekunden
    }

    private void DeactivateHitbox()
    {
        Debug.Log("Hitbox deactivated!");
        weaponHitbox.DeactivateHitbox();
    }
}