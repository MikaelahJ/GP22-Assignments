using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vectors : ProcessingLite.GP21
{
    public Vector2 circlePos;
    public float diameter = 0.5f;
    Vector2 line;

    void Update()
    {
        Background(0);
        Circle(circlePos.x, circlePos.y, diameter);



        if (Input.GetMouseButton(0))
        {
            Line(circlePos.x, circlePos.y, MouseX, MouseY);

            line = new Vector2(MouseX, MouseY)-new Vector2(circlePos.x, circlePos.y) ;

        }
        circlePos += line * 0.001f;

        if(circlePos.y >= Height || circlePos.y <=0)
        {
            line.y *= -1;
            Stroke(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
        }
        if (circlePos.x >= Width || circlePos.x <= 0)
        {
            line.x *= -1;
            Stroke(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
        }
    }
}
