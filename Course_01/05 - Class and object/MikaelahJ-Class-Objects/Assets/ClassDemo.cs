using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassDemo : ProcessingLite.GP21
{
    Ball[] demoBall = new Ball[10];
    Player player;

    void Start()
    {
        player = new Player(Width / 2, Height / 2, 255, 1);
        for (int i = 0; i < demoBall.Length; i++)
        {
            demoBall[i] = new Ball(1 + i, 0.5f + i, Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255), 0.5f);
        }

    }


    void Update()
    {
        Background(0);
        player.Draw();
        player.UpdatePos();

        for (int i = 0; i < demoBall.Length; i++)
        {
            demoBall[i].Draw();
            demoBall[i].UpdatePos();
        }
    }
}
