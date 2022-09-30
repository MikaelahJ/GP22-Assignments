using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment : ProcessingLite.GP21
{
    int color = 000;

    float spaceBetweenLines = 0.2f;
    float k = 0.1f;
    void Update()
    {
        //Clear background
        Background(0);

        //Prepare our stroke settings
        StrokeWeight(0.5f);

        //Draw our scan lines
       
            for (int i = 0; i < Height / spaceBetweenLines; i++)
            {
            k += 0.1f;
                Stroke(0, 255, 10);

                if (i % 3 == 0)
                {
                
                Stroke(255, 0, color);
                }

                //Increase y-cord each time loop run
                float y = i * spaceBetweenLines;

                //Draw a line from left side of screen to the right
                Line(0, y+k, Width, y+k);
            if (k >= 0.3f)
            {
                k = 0.1f;
            }
            }
        

        Stroke(color);
        color = Random.Range(0, 255);

        firstLetter();
        secondLetter();
        thirdLetter();
        fourthLetter();

        BeginShape();
        Vertex(10, 6);
        Vertex(11, 7);
        Vertex(12, 6);
        Vertex(11, 7);
        Vertex(11, 8);
        Vertex(12, 9);
        Vertex(11, 8);
        Vertex(10, 9);
        EndShape();
        Circle(11, 9, 1);


    }

    public int x1;
    public int y1;
    private void firstLetter()
    {
        Triangle(1 + x1, 1 + y1, 1 + x1, 5 + y1, 5 + x1, 5 + y1);
        Triangle(3 + x1, 5 + y1, 7 + x1, 1 + y1, 7 + x1, 5 + y1);
        Triangle(3 + x1, 5 + y1, 5 + x1, 5 + y1, 4 + x1, 2 + y1);
    }
    public int x2;
    public int y2;
    void secondLetter()
    {
        Rect(9 + x2, 5 + y2, 10 + x2, 1 + y2);

    }
    public int x3;
    public int y3;
    void thirdLetter()
    {
        Line(11 + x3, 5 + y3, 11 + x3, 1 + y3);
        Line(11 + x3, 3 + y3, 13 + x3, 5 + y3);
        Line(11 + x3, 3 + y3, 13 + x3, 1 + y3);
    }
    public int x4;
    public int y4;
    void fourthLetter()
    {
        Line(14 + x4, 5 + y4, 14 + x4, 1 + y4);
        Line(14 + x4, 3 + y4, 17 + x4, 5 + y4);
        Line(14 + x4, 3 + y4, 17 + x4, 1 + y4);
    }
}
