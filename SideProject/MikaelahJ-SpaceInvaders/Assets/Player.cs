using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject shotPrefab;
    Vector2 pos;
    private float speed = 5f;
    private float fireRate = 0.2f;
    float timer;
    void Update()
    {
        if (Input.GetKey("space") && timer > fireRate)
        {
            Instantiate(shotPrefab, transform.position, transform.rotation);
            timer = 0;
        }
        timer += Time.deltaTime;
        pos.x += Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        pos.y += Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        transform.position = new Vector2(pos.x, pos.y);
    }
}
