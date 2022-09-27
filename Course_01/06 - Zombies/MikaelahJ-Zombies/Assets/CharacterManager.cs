using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : ProcessingLite.GP21
{
    Zombie[] zombie = new Zombie[100];
    Human[] human = new Human[99];

    bool running = true;
    int j = 0;
    
    void Start()
    {
        for (int i = 0; i < human.Length; i++)
        {
            human[i] = new Human(Random.Range(1, Width - 1), Random.Range(1, Height - 1), 0.2f);
        }

        zombie[j] = new Zombie(Random.Range(1, Width - 1), Random.Range(1, Height - 1), 0, 255, 0, 0.2f);
        j++;

    }

    void Update()
    {
        if (running)
        {
            Background(0);

            for (int i = 0; i < human.Length; i++)
            {
                human[i].Draw();
                human[i].UpdatePos();
                for (int k = 0; k < j; k++)
                {
                    zombie[k].Draw();
                    zombie[k].UpdatePos();

                    if (human[i].Collision(human[i], zombie[k]))
                    {
                        zombie[j] = new Zombie(human[i].position.x, human[i].position.y, 0, 255, 0, 0.2f);
                        j++;
                        human[i] = new Human(0,0,0);
                    }
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                j = 0;
                zombie = new Zombie[100];
                for (int k = 0; k < human.Length; k++)
                {
                    human[k] = new Human(Random.Range(1, Width - 1), Random.Range(1, Height - 1), 0.1f);
                }

                zombie[j] = new Zombie(Random.Range(1, Width - 1), Random.Range(1, Height - 1), 0, 255, 0, 0.1f);

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
