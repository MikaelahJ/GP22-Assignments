using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    private float turningSpeed = 90;
    public float speed = 5;
    private float angle;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }


    void Update()
    {
        angle -= Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;

        rb.MoveRotation(angle);

        float y = Input.GetAxis("Vertical");



        rb.velocity = transform.right * y * speed;











    }
}
