using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicCurves : ProcessingLite.GP21
{
    float spaceBetweenLines = 0.2f;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

        StrokeWeight(0.1f);



        //spaceBetweenLines = Mathf.Sin(Time.time) + 1.2f;
        //spaceBetweenLines *= 0.2f;

        for (int i = 0; i < Height / spaceBetweenLines; i++)
        {
            if (i % 3 == 0)
            {
                int r = Random.Range(0, 256);
                int g = Random.Range(0, 256);
                int b = Random.Range(0, 256);
                Stroke(r, g, b);
            }
            else
            {
                Stroke(255);
            }
            Line(0, Height - i * spaceBetweenLines, Width * i / (Height / spaceBetweenLines), 0);
        }


    }
}
