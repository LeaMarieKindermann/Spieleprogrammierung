using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float approachDistance = 2f;
    public float speed = 5;
    private Rigidbody2D rb;
    public float jumpHeight = 5;
    private bool isGrounded = false;
    private Animator anim;
    private Vector3 rotation;
    private int attackLayerMask;
    private bool isAttacking = false;
    private Collider2D playerHitbox;
    private CapsuleCollider2D weaponHitbox;
    private  int Speerdamage = 5;
    private Transform bat; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.eulerAngles;

        playerHitbox = GetComponent<Collider2D>();
        weaponHitbox = GetComponent<CapsuleCollider2D>();

        weaponHitbox.enabled = false;

        bat = GameObject.FindGameObjectWithTag("bat").transform;
    }

    void Update()
    {
        float direction = Input.GetAxis("Horizontal");

        if (direction != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Return) && !isAttacking)
        {
            Debug.Log("Enter-Taste wurde gedrückt!");
            anim.SetTrigger("isAttacking");
            EnableHitbox();
        }

        if (direction < 0)
        {
            transform.eulerAngles = rotation - new Vector3(0, 180, 0);
            transform.Translate(Vector2.right * -speed * direction * Time.deltaTime);
        }
        if (direction > 0)
        {
            transform.eulerAngles = rotation;
            transform.Translate(Vector2.right * speed * direction * Time.deltaTime);
        }

        if (isGrounded == false)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            isGrounded = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }

        if (weaponHitbox.enabled && collision.gameObject.CompareTag("bat"))
        {
            Debug.Log("Spieler greift Gegner an");
            AttackEnemy();
        }
    }

    void EnableHitbox()
    {
        ActivateHitboxWithDelay();
    }

    void AttackEnemy()
    {
        Debug.Log("Spieler greift Gegner an und verursacht " + Speerdamage + " Schaden!");
        bat.GetComponent<BatHealth>().TakeDamage(Speerdamage);
    }

    public void ActivateHitboxWithDelay()
    {
        Debug.Log("Hitbox activated!");
        weaponHitbox.enabled = true;
        Invoke("DeactivateHitbox", 0.4f); // Deaktiviere die Hitbox nach 0.1 Sekunden
    }

    private void DeactivateHitbox()
    {
        Debug.Log("Hitbox deactivated!");
        weaponHitbox.enabled = false;
    } 
}
