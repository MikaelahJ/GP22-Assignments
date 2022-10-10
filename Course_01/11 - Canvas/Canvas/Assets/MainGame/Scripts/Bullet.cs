using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    float bulletspeed = 10;
    public Counter counter;
    void Start()
    {
        counter = GameObject.Find("CounterGO").GetComponent<Counter>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletspeed;
        Destroy(this.gameObject, 5);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            counter.UpdatePoints();
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
