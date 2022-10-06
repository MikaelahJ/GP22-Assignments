using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 2f;
    private Rigidbody2D rb;

    private Transform target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;
        Debug.Log(target);
    }

    void Update()
    {
        transform.up = target.transform.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
