using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ProcessingLite.GP21
{
    Vector2 pos;
    float diameter = 0.5f;
    float maxSpeed = 20;

    float v;
    float a = 5;
    Vector2 dir;
    Vector2 zero;

    void Update()
    {
        Background(0);

        v += a * Time.deltaTime;
        if (v > maxSpeed)
        {
            v = maxSpeed;
        }

        dir.x += v * Input.GetAxis("Horizontal") * Time.deltaTime;
        dir.y += v * Input.GetAxis("Vertical") * Time.deltaTime;

        pos += dir * Time.deltaTime;
        pos = Vector2.Lerp(pos, zero, Time.deltaTime);



        Stroke(255);
        Circle(pos.x, pos.y, diameter);
    }
}