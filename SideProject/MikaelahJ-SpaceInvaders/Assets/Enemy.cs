using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector2 pos;
    private Rigidbody2D rb;
    float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * speed ;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.position.x < -10)
        {
            Destroy(gameObject);
        }
    }


    
}
