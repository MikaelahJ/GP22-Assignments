using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : ProcessingLite.GP21
{
    public Vector2 position;
    Vector2 velocity;

    float size;

    public Human(float x, float y, float _size)
    {
        position.x = x;
        position.y = y;
        size = _size;

        velocity = new Vector2();
        velocity.x = Random.Range(0, 11) - 5;
        velocity.y = Random.Range(0, 11) - 5;

    }

    public void Draw()
    {
        Stroke(0, 0, 255);
        Fill(0, 0, 255);
        Circle(position.x, position.y, size);
    }

    public void UpdatePos()
    {
        position += velocity * Time.deltaTime;

        if ((position.x) >= Width)
        {
            position.x += 0;
        }
        if ((position.x) <= 0)
        {
            position.x += Width;
        }
        if ((position.y) >= Height)
        {
            position.y += 0;
        }
        if ((position.y) <= 0)
        {
            position.y += Height;
        }
    }

    public bool Collision(Human human, Zombie zombie)
    {
        float maxdistance = (human.size / 2) + (zombie.size / 2);

        if (Mathf.Abs(human.position.x - zombie.position.x) > maxdistance || Mathf.Abs(human.position.y - zombie.position.y) > maxdistance)
        {
            return false;
        }
        else if (Vector2.Distance(new Vector2(human.position.x, human.position.y), new Vector2(zombie.position.x, zombie.position.y)) > maxdistance)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    //public void Remove()
    //{
    //    Destroy(this);
    //}
}

