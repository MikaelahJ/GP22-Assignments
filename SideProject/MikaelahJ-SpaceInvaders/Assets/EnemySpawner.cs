using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    float timer;
    float spawnRate = 0.5f;
    Vector2 pos;

    float height = 3;

    void Update()
    {
        if (timer > spawnRate)
        {
            spawnEnemy();
            timer = 0;
        }
        timer += Time.deltaTime;
    }
    void spawnEnemy()
    {
        pos.y = Random.Range(-height, height);
        pos.x = 7;
        Instantiate(enemyPrefab, pos, Quaternion.identity);

    }
}
