using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMobs : MonoBehaviour
{
    Vector2 startPos;
    bool moving = false;
    float timer;
    float startTime = 8f;
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > startTime)
            {
                moving = true;
                timer = 0;
            }
        if (moving)
        {
            transform.Translate(Vector3.right * 0.01f, Camera.main.transform);

            if (transform.position.x > 10)
            {
                moving = false;
                transform.position = startPos;
            }
        }
    }
}
