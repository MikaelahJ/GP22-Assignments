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
    List<Vector2> pastPos = new List<Vector2>();
    Vector2[] possibleDir = new Vector2[] { new Vector2(-1, 0), new Vector2(1, 0), new Vector2(0, -1), new Vector2(0, 1) };
    int nextDir;
    bool inArea = true;
    bool finding;

    public string GetName()
    {
        return "Kalle"; //When asked, tell them our walkers name
    }

    public Vector2 GetStartPosition(int playAreaWidth, int playAreaHeight)
    {
        areaWidth = playAreaWidth;
        areaHeight = playAreaHeight;
        //Select a starting position or use a random one.
        float x = Random.Range(0, playAreaWidth);
        float y = Random.Range(0, playAreaHeight);

        //a PVector holds floats but make sure its whole numbers that are returned!
        return new Vector2(x, y);
    }

    public Vector2 Movement()
    {
        //add your own walk behavior for your walker here.
        //Make sure to only use the outputs listed below.
        finding = true;
        int i = 0;
        while (finding == true)
        {
            i++;

            nextDir = Random.Range(0, 4);

            nextPos = currentPos + possibleDir[nextDir];
            Debug.Log("nextDir: " + nextDir);

            if (nextPos.x < 0 || nextPos.x > areaWidth || nextPos.y < 0 || nextPos.y > areaHeight)
            {
                inArea = false;
                Debug.Log("out");
            }
            else
            {
                inArea = true;
                Debug.Log("in");
            }

            if (!pastPos.Contains(nextPos) && inArea == true)
            {
                Debug.Log("moving");
                currentPos = nextPos;
                pastPos.Add(currentPos);
                finding = false;
            }
            if (i >= 4)
            {

            }
        }

        return possibleDir[nextDir];










        //for (int i = 0; i < possibleDir.Length; i++)
        //{
        //    nextDir = Random.Range(0, 4);

        //    nextPos = currentPos + possibleDir[nextDir];





        //    if (nextPos.x < 0 || nextPos.x > areaWidth || nextPos.y < 0 || nextPos.y > areaHeight)
        //    {

        //        inArea = false;
        //    }
        //    else
        //    {
        //        inArea = true;
        //    }

        //    if (!pastPos.Contains(nextPos) && inArea)
        //    {
        //        currentPos = nextPos;
        //        pastPos.Add(currentPos);
        //        break;
        //    }
        //}
        //return possibleDir[nextDir];
    }
}

//All valid outputs:
// Vector2(-1, 0);
// Vector2(1, 0);
// Vector2(0, 1);
// Vector2(0, -1);

//Any other outputs will kill the walker!