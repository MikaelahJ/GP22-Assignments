using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] AudioSource audio;
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.up = (Vector3)mousePos - transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            audio.Play();
            Instantiate(BulletPrefab, transform.position, transform.rotation);
        }
    }
}
