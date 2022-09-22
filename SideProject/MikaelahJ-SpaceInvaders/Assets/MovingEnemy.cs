using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : Enemy
{

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.Rotate(0, 0, 45);

        rb.velocity = new Vector2( -Mathf.Sin(Time.time) * 1, 0) * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
