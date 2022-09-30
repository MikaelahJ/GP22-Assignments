using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : ProcessingLite.GP21
{
    //Zombie[] zombie;
    //Human[] human = new Human[99];
    List<Human> humans;
    List<Zombie> zombies;


    bool running;
    int z;

    void Start()
    {
        humans = new List<Human>(99);
        zombies = new List<Zombie>(100);


        running = true;
        z = 0;

        for (int i = 0; i < 99; i++)
        {
            humans.Add(new Human(Random.Range(1, Width - 1), Random.Range(1, Height - 1), 0.2f));
        }
        zombies.Add(new Zombie(Random.Range(1, Width - 1), Random.Range(1, Height - 1), 0, 255, 0, 0.2f));
        z++;
    }

    void Update()
    {
        if (running)
        {
            Background(0);
            Debug.Log(humans.Count + " " + zombies.Count);


            for (int i = 0; i < humans.Count; i++)
            {
                humans[i].Draw();
                humans[i].UpdatePos();

                for (int k = 0; k < z; k++)
                {
                    zombies[k].Draw();
                    zombies[k].UpdatePos();

                    if (humans[i].Collision(humans[i], zombies[k]))
                    {
                        humans.RemoveAt(i);
                        zombies.Add(new Zombie(zombies[k].position.x, zombies[k].position.y, 0, 255, 0, 0.2f));

                        z = zombies.Count;

                        if (z == 100)
                        {
                            Background(0);
                            GameOver();
                        }
                    }
                }
            }
            //Force gameOver
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Background(0);
                GameOver();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Start();
            }
        }
    }

    void GameOver()
    {
        running = false;
        Stroke(255, 0, 0);
        Fill(255, 0, 0);
        TextSize(20);
        Text("Game Over", Width / 2, (Height / 2) - 1);
        Text("R to Restart", Width / 2, (Height / 2) - 2);
    }
}
