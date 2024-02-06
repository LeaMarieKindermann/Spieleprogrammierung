using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPlayer : MonoBehaviour
{
  
    public float approachDistance = 2f;
    public float speed = 5;
    private Rigidbody2D rb;
    public float jumpHeight = 5;
    private bool isGrounded = false;
    private Animator anim;
    private Vector3 rotation;
    private int attackLayerMask;
    private Collider2D playerHitbox;
    private Transform bat; 
  
   
    
 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.eulerAngles;

        playerHitbox = GetComponent<Collider2D>();
    
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
        
       
    }




}


