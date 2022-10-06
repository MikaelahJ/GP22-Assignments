using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            spriteRenderer.color = Color.blue;
        }
        if (other.gameObject.CompareTag("Player2"))
        {
            spriteRenderer.color = Color.yellow;
        }
    }
}
