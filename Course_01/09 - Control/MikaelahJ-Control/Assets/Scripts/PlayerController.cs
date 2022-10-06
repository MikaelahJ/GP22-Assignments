using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    private float x, y;
    Vector2 movement;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        movement = new Vector2(x, y) * speed;

        //transform.Translate(movement);

        //transform.position += movement;

        //rb.AddForce(movement);

        rb.velocity = movement;

        Vector2 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.up = (Vector3)mousePos - transform.position;
    }
}
