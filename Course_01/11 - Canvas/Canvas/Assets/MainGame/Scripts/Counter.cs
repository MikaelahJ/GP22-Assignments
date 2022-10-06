using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Counter : MonoBehaviour
{
    public TMP_Text text;
    private int points = 0;

    void Start()
    {
        text.text = "Points: 0";
    }
    public void UpdatePoints()
    {
        points++;
        text.text = "Points: " + points.ToString();
    }
}
