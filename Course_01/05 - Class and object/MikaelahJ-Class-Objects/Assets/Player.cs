using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ProcessingLite.GP21
{
    public Vector2 position;
    float maxSpeed = 20;
    float v;
    float a = 5;
    Vector2 dir;

    float size;
    int colour;

    public Player(float x, float y, int _colour, float _size)
    {
        position.x = x;
        position.y = y;
        size = _size;
        colour = _colour;
    }

    public void Draw()
    {
        Stroke(colour);
        Fill(colour);
        Circle(position.x, position.y, size);
    }

    public void UpdatePos()
    {
        v += a * Time.deltaTime;
        if (v > maxSpeed)
        {
            v = maxSpeed;
        }

        dir.x += v * Input.GetAxis("Horizontal") * Time.deltaTime;
        dir.y += v * Input.GetAxis("Vertical") * Time.deltaTime;

        position += dir * Time.deltaTime;

        if ((position.x + (size / 2)) >= Width || (position.x - (size / 2)) <= 0)
        {
            dir.x *= -1;
        }
        if ((position.y + (size / 2)) >= Height || (position.y - (size / 2)) <= 0)
        {
            dir.y *= -1;
        }
    }

}

