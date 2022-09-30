using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ProcessingLite.GP21
{
    Vector2 pos;
    float diameter = 3f;
    float maxSpeed = 5f;
    [SerializeField] float deAcc = 0.25f;

    float vel = 2f;
    Vector2 acc;
    Vector2 dir;

    private void Start()
    {
        pos.x = Width / 2;
        pos.y = Height / 2;
    }
    void Update()
    {
        Background(0);

        dir += new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (dir.magnitude > maxSpeed)
        {
            dir = dir.normalized * maxSpeed;
        }

        acc += dir * vel * Time.deltaTime;

        if (Input.anyKey == false)
        {
            acc *= deAcc;
        }

        pos += acc * Time.deltaTime;


        if (pos.x > Width * 2)
        {
            pos.x = -Width;
        }
        if (pos.x < -Width)
        {
            pos.x = Width * 2;
        }
        if (pos.y > Height * 2)
        {
            pos.y = -Height;
        }
        if (pos.y < -Height)
        {
            pos.y = Height * 2;
        }

        

        Draw();
    }

    private void Draw()
    {
        Stroke(0, 158, 163);

        Circle(pos.x, pos.y, diameter);
        Circle(pos.x + Width, pos.y, diameter);
        Circle(pos.x - Width, pos.y, diameter);

        Circle(pos.x, pos.y + Height, diameter);
        Circle(pos.x - Width, pos.y + Height, diameter);
        Circle(pos.x + Width, pos.y + Height, diameter);

        Circle(pos.x, pos.y - Height, diameter);
        Circle(pos.x - Width, pos.y - Height, diameter);
        Circle(pos.x + Width, pos.y - Height, diameter);




    }
}
