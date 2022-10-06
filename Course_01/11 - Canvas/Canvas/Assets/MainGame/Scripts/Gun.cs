using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;


    void Update()
    {
        Vector2 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        transform.up = (Vector3)mousePos - transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(BulletPrefab, transform.position, transform.rotation);
        }
    }
}
