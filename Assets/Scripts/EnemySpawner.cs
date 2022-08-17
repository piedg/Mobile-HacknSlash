using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> Enemies = new List<GameObject>();
    [SerializeField] int nEnemiesToSpawn;
    [SerializeField] float spawnDelay;
    [field: SerializeField] public float remainingSpawnTime;

    [SerializeField] Transform Player;
    float Offset = 10f;

    private void Update()
    {
        if(GameManager.Instance.Player.IsDead) { return; }

        remainingSpawnTime -= Time.deltaTime;

        if (remainingSpawnTime <= 0f)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < nEnemiesToSpawn; i++)
        {
            Instantiate(Enemies[Random.Range(0, Enemies.Count)], new Vector2(
                Random.Range(
                    -(Player.position.x + Offset),
                    Player.position.x + Offset
                    ),
                Random.Range(
                    -(Player.position.y + Offset),
                    Player.position.y + Offset
                    )
                ),
                Quaternion.identity);
        }

        remainingSpawnTime = spawnDelay;
    }
}
