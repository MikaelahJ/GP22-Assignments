using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    Vector2 movement;
    float direction;
    float speed = 5;
    float jumpForce = 4;
    int jumpCount = 0;

    bool facingLeft;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        if (direction > 0)
        { facingLeft = true; }
        else if (direction < 0)
        { facingLeft = false; }

        if (Input.GetKeyDown("space") && jumpCount < 3)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            characterState(CharacterState.Flying);

            //jumpCount++;
        }

        movement.x = direction * speed;
        movement.y = rb.velocity.y;
        rb.velocity = movement;

        if (facingLeft)
        {
            spriteRenderer.flipX = true;
        }
        else if (!facingLeft)
        {
            spriteRenderer.flipX = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            characterState(CharacterState.Idle);
            jumpCount = 0;
        }
        if (collision.gameObject.tag == "Item")
        {
            characterState(CharacterState.PickUp);
        }
    }
    enum CharacterState
    {
        Idle,
        Flying,
        PickUp
    }
    void characterState(CharacterState state)
    {
        switch (state)
        {
            case CharacterState.Idle:
                animator.Play("PlayerIdle");
                break;

            case CharacterState.Flying:
                animator.Play("PlayerFlying");
                break;

            case CharacterState.PickUp:
                animator.Play("PlayerEating");
                break;
        }
    }
}
