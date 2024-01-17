using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float approachDistance = 2f; // Entfernung, bei der die Animation ausgelöst wird
    public float speed = 5;
    private Rigidbody2D rb;
    public float jumpHight = 5;
    private bool isGrounded = false;
    private Animator anim; 
    private Vector3 rotation;
    private float vertical;
    public int Speerdamage = 5; 
    private Transform bat; 

      // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.eulerAngles;
        bat = GameObject.FindGameObjectWithTag("bat").transform;
        
    }

    // Update is called once per frame
    void Update()
    {

        // richtung bestimmen
        float richtung = Input.GetAxis("Horizontal");

        // animation bestimmen
        if(richtung != 0){
            anim.SetBool("isRunning", true);
        }
        else {
            anim.SetBool("isRunning", false);
        }

        // Angriffsanimation Speer
        if (Input.GetKeyDown(KeyCode.Return))  // Überprüfen Sie, ob die Enter-Taste gedrückt wird.
        {
            Debug.Log("Enter-Taste wurde gedrückt!");
            anim.SetTrigger("isAttacking");  // Setzen Sie den Attack-Trigger.
            AttackEnemy();
        }

        // blickrichtung und bewegung
        if (richtung < 0){
            transform.eulerAngles = rotation - new Vector3(0, 180, 0);
              transform.Translate(Vector2.right * -speed * richtung * Time.deltaTime);
        }
        if (richtung > 0){
            transform.eulerAngles = rotation;
              transform.Translate(Vector2.right * speed * richtung * Time.deltaTime);
        }

    // Sprung Animation
    if(isGrounded == false ){
          anim.SetBool("isJumping", true);
        }
        else {
            anim.SetBool("isJumping", false);
        }
      

        // Springen 
        if (Input.GetKeyDown(KeyCode.Space) &&  isGrounded)
        {
            rb.AddForce( Vector2.up * jumpHight, ForceMode2D.Impulse);
            isGrounded = false;
        }


    }

    // testen ob Spieler etwas berührt
        private void OnCollisionEnter2D(Collision2D collision){
            if( collision.gameObject.tag == "ground"){
                isGrounded = true; 
            }
           

        }

    // Methode, um den Attack-Trigger zurückzusetzen
    public void ResetAttackTrigger()
    {
        Debug.Log("Reset aufgeführt");
        anim.ResetTrigger("isAttacking");
    }

    void AttackEnemy()
    {
        // Hier können Sie weitere Logik hinzufügen, z. B. Animation, Sound usw.
        //batAnimator.SetTrigger("Attack");
        Debug.Log("Spieler greift Gegner an und verursacht " + Speerdamage + " Schaden!");

        // Fügen Sie dem Spieler Schaden hinzu.
        // Sie müssen eine Referenz zum Spieler-Skript haben, um ihm Schaden zuzufügen.
        bat.GetComponent<BatHealth>().TakeDamage(Speerdamage);
    }

     
}
