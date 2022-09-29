using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : ProcessingLite.GP21
{
    public Vector2 position;
    Vector2 dir;

    public float size;
    float speed = 0.01f;
    int r;
    int g;
    int b;

    public Zombie(float x, float y, int _r, int _g, int _b, float _size)
    {
        position.x = x;
        position.y = y;
        size = _size;
        r = _r;
        g = _g;
        b = _b;

        dir = new Vector2();
        dir.x = Random.Range(0, 11) - 5;
        dir.y = Random.Range(0, 11) - 5;

    }

    public void Draw()
    {
        Stroke(r, g, b);
        Fill(0);
        Circle(position.x, position.y, size);
    }

    public void UpdatePos()
    {


        position += dir * Time.deltaTime * speed;

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
