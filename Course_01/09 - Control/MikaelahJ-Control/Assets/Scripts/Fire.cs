using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject BulletPrefab;
   

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(BulletPrefab, transform.position, transform.rotation);
        }
    }
}
