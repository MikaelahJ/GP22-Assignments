using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : ProcessingLite.GP21
{
    public Vector2 position;
    Vector2 velocity;

    public float size;
    int r;
    int g;
    int b;

    public Ball(float x, float y, int _r, int _g, int _b, float _size)
    {
        position.x = x;
        position.y = y;
        size = _size;
        r = _r;
        g = _g;
        b = _b;

        velocity = new Vector2();
        velocity.x = Random.Range(0, 11) - 5;
        velocity.y = Random.Range(0, 11) - 5;

    }

    public void Draw()
    {
        Stroke(r, g, b);
        Fill(0);
        Circle(position.x, position.y, size);
    }

    public void UpdatePos()
    {


        position += velocity * Time.deltaTime;

        if ((position.x + (size / 2)) >= Width || (position.x - (size / 2)) <= 0)
        {
            velocity.x *= -1;
        }
        if ((position.y + (size / 2)) >= Height || (position.y - (size / 2)) <= 0)
        {
            velocity.y *= -1;
        }
    }

}
