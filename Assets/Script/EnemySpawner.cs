using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    public float timer;
    public float spawnCountDown;
    public float spawnDelay;
    public float safeZone;
    public float spawnZone;
    public int phaseTime;
    public int phaseCount;

    public Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spawnCountDown += Random.Range(0f, 10f);
    }

    void Update()
    {
        int length = enemy.Length;
        float distanceFromPlayer = Vector3.Distance(player.position, transform.position);
        spawnCountDown -= Time.deltaTime;
        timer += Time.deltaTime;
        if (timer < phaseCount && spawnCountDown < 0 && distanceFromPlayer <= spawnZone && distanceFromPlayer > safeZone)
        {
            int id = Random.Range(0, length);

            spawnCountDown = spawnDelay + Random.Range(0f, 10f);

            SpawnEnemy(id);
        }
        else if (timer > phaseCount)
        {
            phaseCount += phaseTime;
            spawnDelay = spawnDelay / 2;
        }

    }

    private void SpawnEnemy(int id)
    {
        Vector3 randomizedLocation = new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-15f, 15f));
        Vector3 enemyLocation = transform.localPosition + randomizedLocation;
        Instantiate(enemy[id], enemyLocation, Quaternion.identity);
    }
}
