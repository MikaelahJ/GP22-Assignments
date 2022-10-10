using UnityEngine;
using System.Collections.Generic;

class MikJen : IRandomWalker
{
    //Add your own variables here.
    //Do not use processing variables like width or height
    int areaWidth;
    int areaHeight;
    Vector2 currentPos;
    Vector2 nextPos;
    Vector2[] possibleDir = new Vector2[] { new Vector2(-1, 0), new Vector2(0, -1), new Vector2(1, 0), new Vector2(0, 1) };
    List<Vector2> pastPos = new List<Vector2>();
    int nextDir;
    int maxDistance = 5;
    int distance;
    int i = 0;

    public string GetName()
    {
        return "Mikk"; //When asked, tell them our walkers name
    }

    public Vector2 GetStartPosition(int playAreaWidth, int playAreaHeight)
    {
        areaWidth = playAreaWidth;
        areaHeight = playAreaHeight;
        //Select a starting position or use a random one.
        float x = playAreaWidth - 6;
        float y = playAreaHeight - 5;

        //a PVector holds floats but make sure its whole numbers that are returned!
        currentPos = new Vector2(x, y);
        return new Vector2(x, y);
    }

    public Vector2 Movement()
    {
        //add your own walk behavior for your walker here.
        //Make sure to only use the outputs listed below.

        nextPos = currentPos + possibleDir[nextDir];
        //Debug.Log("current" + currentPos);
        //Debug.Log("next" + nextPos);
        if (i == 0 || i == 2)
        {
            //distance between nextPos and left and right wall
            float distance1 = Vector2.Distance(nextPos, new Vector2(0, nextPos.y));
            float distance2 = Vector2.Distance(nextPos, new Vector2(areaWidth, nextPos.y));

            if (distance1 < maxDistance || distance2 < maxDistance)
            {
                i++;
                if (i == 4)
                {
                    i = 0;
                }
            }
            else
            {
                for (int k = 0; k < pastPos.Count; k++)
                {
                    //distance between nextPos and pastPos
                    if (i == 0)
                    {
                        if (Vector2.Distance(new Vector2(nextPos.x - 5, nextPos.y), new Vector2(pastPos[k].x, nextPos.y)) < maxDistance)
                        {
                            i++;
                            if (i == 4)
                            {
                                i = 0;
                            }
                        }
                    }
                    else if (i == 2)
                    {
                        if (Vector2.Distance(new Vector2(nextPos.x + 5, nextPos.y), new Vector2(pastPos[k].x, nextPos.y)) < maxDistance)
                        {
                            Debug.Log("past " + pastPos[k].x);
                            Debug.Log("next " + nextPos.x);

                            i++;
                            if (i == 4)
                            {
                                i = 0;
                            }
                        }
                    }
                }
            }
        }
        else if (i == 1 || i == 3)
        {
            //distance between nextPos and floor and roof
            float distance1 = Vector2.Distance(nextPos, new Vector2(nextPos.x, 0));
            float distance2 = Vector2.Distance(nextPos, new Vector2(nextPos.x, areaHeight));

            if (distance1 < maxDistance || distance2 < maxDistance)
            {
                i++;
                if (i == 4)
                {
                    i = 0;
                }
            }
            else
            {
                for (int k = 0; k < pastPos.Count; k++)
                {
                    //distance between nextPos and pastPos
                    if (i == 1)
                    {
                        if (Vector2.Distance(new Vector2(nextPos.x, nextPos.y - 5), new Vector2(nextPos.x, pastPos[k].y)) < maxDistance)
                        {
                            i++;
                            if (i == 4)
                            {
                                i = 0;
                            }
                        }
                    }
                    else if (i == 3)
                    {
                        if (Vector2.Distance(new Vector2(nextPos.x, nextPos.y + 5), new Vector2(nextPos.x, pastPos[k].y)) < maxDistance)
                        {
                            i++;
                            if (i == 4)
                            {
                                i = 0;
                            }
                        }
                    }
                }
            }
        }



        nextDir = i;
        currentPos = nextPos;
        pastPos.Add(nextPos);
        return possibleDir[nextDir];
    }
}

//All valid outputs:
// Vector2(-1, 0);
// Vector2(1, 0);
// Vector2(0, 1);
// Vector2(0, -1);

//Any other outputs will kill the walker!