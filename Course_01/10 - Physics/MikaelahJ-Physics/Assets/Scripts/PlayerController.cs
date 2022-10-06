using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    public float speed = 5;
    public float jumpPower = 10;
    bool facingLeft;
    Rigidbody2D rb2d;
    Vector2 movement = new Vector2();

    bool grounded;

    GameObject p1;
    GameObject p2;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if (x < 0)
        {
            facingLeft = true;
        }
        else if (x > 0)
        {
            facingLeft = false;
        }

        //Only update x direction
        movement.x = x * speed;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            //velocity jump
            //rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);

            //impulse jump (same result)
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0); //Reset our y speed before the jump
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        //Use our old y velocity, if movement.y = 0, then we mess with gravity
        movement.y = rb2d.velocity.y;

        //Update our movement
        rb2d.velocity = movement;


        if (movement.x == 0)
        {
            animator.SetBool("isIdle", true);
        }
        else
        {
            animator.SetBool("isIdle", false);
        }
        if (facingLeft)
        {
            spriteRenderer.flipX = true;
        }
        else if (!facingLeft)
        {
            spriteRenderer.flipX = false;
        }
    }

    //This is not the best way of controlling if we are grounded.
    //We will look at better solutions at a later date.
    void OnTriggerEnter2D(Collider2D other)
    {
        grounded = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        grounded = false;
    }
}