using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
     private float vertical;
    private float speed = 5f;
    private bool isLadder;
    private bool isClimbing;
    private Rigidbody2D rb;
     private Animator anim; 
      public AudioSource climbAudio;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
         anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
     vertical = Input.GetAxisRaw("Vertical");

          if (isLadder && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)))
        {
            climbAudio.Play();
        }

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            
            anim.SetBool("isClimbing", true);
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 2f;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ladder"))
        {
            isLadder = true;

           
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ladder"))
        {
            
            isLadder = false;
            anim.SetBool("isClimbing", false);
            isClimbing = false;
            
        }
    }
}
