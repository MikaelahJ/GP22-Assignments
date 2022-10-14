using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Counter : MonoBehaviour
{
    public TMP_Text text;
    private int points = 0;
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        text.text = "Points: 0";
    }
    public void UpdatePoints()
    {
        audio.Play();
        points++;
        text.text = "Points: " + points.ToString();
    }
}
