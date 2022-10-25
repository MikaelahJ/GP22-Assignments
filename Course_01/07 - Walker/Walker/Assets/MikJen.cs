using UnityEngine;
using System.Collections.Generic;
using System;

class MikJen : IRandomWalker
{
    //Add your own variables here.
    //Do not use processing variables like width or height
    int areaWidth;
    int areaHeight;
    Vector2 currentPos;
    Vector2 nextPos;
    Vector2[] possibleDir = new Vector2[] { new Vector2(-1, 0), new Vector2(0, -1), new Vector2(1, 0), new Vector2(0, 1) };
    Vector2[] pastPos = new Vector2[4];
    int nextDir;
    int maxDistance = 5;
    int maxDistanceInner = 2;
    int i = 0;

    public string GetName()
    {
        return "Mikaelah"; //When asked, tell them our walkers name
    }

    public Vector2 GetStartPosition(int playAreaWidth, int playAreaHeight)
    {
        areaWidth = playAreaWidth;
        areaHeight = playAreaHeight;
        //Select a starting position or use a random one.
        float x = playAreaWidth - 4;
        float y = playAreaHeight - 4;

        //a PVector holds floats but make sure its whole numbers that are returned!
        currentPos = new Vector2(x, y);
        return new Vector2(x, y);
    }

    public Vector2 Movement()
    {
        //add your own walk behavior for your walker here.
        //Make sure to only use the outputs listed below.
        Move();

        nextDir = i;
        currentPos = nextPos;
        return possibleDir[nextDir];
    }

    private Vector2 Move()
    {
        nextPos = currentPos + possibleDir[nextDir];

        if (i == 0 || i == 2)
        {
            //distance between nextPos and left and right wall
            float distance1 = Vector2.Distance(nextPos, new Vector2(0, nextPos.y));
            float distance2 = Vector2.Distance(nextPos, new Vector2(areaWidth, nextPos.y));

            float distanceInner1 = Vector2.Distance(nextPos, new Vector2(pastPos[0].x, nextPos.y));
            float distanceInner2 = Vector2.Distance(nextPos, new Vector2(pastPos[2].x, nextPos.y));

            if (pastPos[0] != Vector2.zero && pastPos[2] != Vector2.zero)
            {
                if (i == 0 && distanceInner1 < maxDistanceInner)
                {
                    Rotate();
                    return nextPos;
                }
                else if (i == 2 && distanceInner2 < maxDistanceInner)
                {
                    Rotate();
                    return nextPos;
                }
            }
            else if (distance1 < maxDistance || distance2 < maxDistance)
            {
                Rotate();
                return nextPos;
            }
        }
        else if (i == 1 || i == 3)
        {
            //distance between nextPos and floor and roof
            float distance1 = Vector2.Distance(nextPos, new Vector2(nextPos.x, 0));
            float distance2 = Vector2.Distance(nextPos, new Vector2(nextPos.x, areaHeight));

            float distanceInner1 = Vector2.Distance(nextPos, new Vector2(nextPos.x, pastPos[1].y));
            float distanceInner2 = Vector2.Distance(nextPos, new Vector2(nextPos.x, pastPos[3].y));

            if (pastPos[1] != Vector2.zero && pastPos[3] != Vector2.zero)
            {
                if (i == 1 && distanceInner1 < maxDistanceInner)
                {
                    Rotate();
                    return nextPos;
                }
                else if (i == 3 && distanceInner2 < maxDistanceInner)
                {
                    Rotate();
                    return nextPos;
                }
            }
            else if (distance1 < maxDistance || distance2 < maxDistance)
            {
                Rotate();
                return nextPos;
            }
        }
        return nextPos;
    }

    private void Rotate()
    {
        pastPos[i] = nextPos;
        i++;

        if (i == 4)
        {
            i = 0;
        }
    }

}

//All valid outputs:
// Vector2(-1, 0);
// Vector2(1, 0);
// Vector2(0, 1);
// Vector2(0, -1);

//Any other outputs will kill the walker!