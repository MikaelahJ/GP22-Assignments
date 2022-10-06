using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    [SerializeField] Transform target;

    Vector2 pos;
    float height, width;
    float speed = 2f;

    float timer;
    float spawnRate = 0.5f;
    void Start()
    {

        Camera cam = Camera.main;
        height = 2f + cam.orthographicSize;
        width = height * cam.aspect;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnRate)
        {
            spawnEnemy();
            timer = 0;
        }
    }
    void spawnEnemy()
    {
        int randomY = Random.Range(0, 2);
        if (randomY == 0)
        {
            pos.y = height;
        }
        else
        {
            pos.y = -height;
        }
        pos.x = Random.Range(-width, width);


        Instantiate(enemyPrefab, pos, Quaternion.identity);

    }
}
