using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 direction;
    float bulletspeed = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletspeed;
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            direction = Vector3.Reflect(transform.up, collision.GetContact(0).normal);
            rb.velocity = (direction).normalized * bulletspeed;

            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg + 90;
            Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rot;
        }
    }
}
