using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassDemo : ProcessingLite.GP21
{
    Ball[] demoBall = new Ball[100];
    Player player;
    int i = 0;
    bool running = true;

    float spawnRate = 3f;
    float timer;
    void Start()
    {
        running = true;
        player = new Player(Width / 2, Height / 2, 255, 0.5f);
        demoBall[i] = new Ball(Random.Range(1, Width - 1), Random.Range(1, Height - 1), Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255), 0.2f);
        i++;

    }

    void Update()
    {
        if (running)
        {
            if (timer > spawnRate && i != 100)
            {
                
                demoBall[i] = new Ball(Random.Range(1, Width - 1), Random.Range(1, Height - 1), Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255), 0.2f);
                i++;
                timer = 0;
            }
            timer += Time.deltaTime;

            Background(0);
            player.Draw();
            player.UpdatePos();

            for (int k = 0; k < i; k++)
            {
                demoBall[k].Draw();
                demoBall[k].UpdatePos();

                if (player.Collision(player, demoBall[k]))
                {
                    GameOver();
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                demoBall = new Ball[100];
                player = new Player(Width / 2, Height / 2, 255, 0.5f);
                i = 0;
                demoBall[i] = new Ball(Random.Range(1, Width - 1), Random.Range(1, Height - 1), Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255), 0.2f);
                i++;
                running = true;
                
            }
        }
    }
    void GameOver()
    {
        running = false;
        Stroke(255, 0, 0);
        Fill(255, 0, 0);
        Text("Game Over", Width / 2, (Height / 2) - 1);
        Text("R to Restart", Width / 2, (Height / 2) - 2);
    }
}
