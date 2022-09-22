using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    List<GameObject> enemies = new List<GameObject>();


    Vector2 pos;

    float height = 4;

    [SerializeField] GameObject[] wave1;
    [SerializeField] GameObject[] wave2;
    [SerializeField] GameObject[] wave3;

    int currentWave = 1;
    bool ongoingWave = false;
    float betweenSpawns = 2f;

    void Update()
    {
        enemies.RemoveAll(s => s == null);

        if (enemies.Count == 0)
        {
            ongoingWave = false;
        }

        if (ongoingWave == false)
        {
            StartCoroutine(spawnWave());

        }
    }

    IEnumerator spawnWave()
    {
        ongoingWave = true;
        switch (currentWave)
        {

            case 1:
                currentWave++;
                foreach (GameObject enemy in wave1)
                {
                    spawnEnemy();
                    yield return new WaitForSeconds(1f);
                }
                break;

            case 2:
                currentWave++;
                betweenSpawns *= 0.5f;

                foreach (GameObject enemy in wave2)
                {
                    spawnEnemy();
                    yield return new WaitForSeconds(betweenSpawns);

                }
                break;

            case 3:
                currentWave++;
                betweenSpawns *= 0.5f;


                foreach (GameObject enemy in wave3)
                {
                    spawnEnemy();
                    yield return new WaitForSeconds(1f);

                }
                break;

        }


    }
    void spawnEnemy()
    {
        pos.y = Random.Range(-height, height);
        pos.x = 10;

        GameObject enemy = Instantiate(enemyPrefab, pos, Quaternion.identity);
        enemies.Add(enemy);

    }
}
