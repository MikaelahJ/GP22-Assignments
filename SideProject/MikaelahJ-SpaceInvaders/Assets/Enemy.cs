using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public float speed = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * speed;
    }


    void Update()
    {
        if (rb.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
