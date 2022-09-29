using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<ObjectPool> EnemyPools = new List<ObjectPool>();
    [SerializeField] int nEnemiesToSpawn;
    [SerializeField] float spawnDelay;

    [SerializeField] Transform Player;
    float remainingSpawnTime;
    float Offset = 50f;

    private void Update()
    {
        if(GameManager.Instance.Player.IsDead) { return; }
        if(GameManager.Instance.IsPause) { return; }

        remainingSpawnTime -= Time.deltaTime;

        if (remainingSpawnTime <= 0f)
        {
            InstantiateEnemy(GetRandomEnemy(), Player.position, Offset);
        }
    }

    GameObject GetRandomEnemy()
    {
        return EnemyPools[Random.Range(0, EnemyPools.Count)].GetObjectFromPool();
    }

    void InstantiateEnemy(GameObject enemy, Vector3 center, float range)
    {
        float randomX = Random.Range(center.x - range, center.x + range);
        float randomY = Random.Range(center.y - range, center.y + range);

        enemy.transform.SetPositionAndRotation(new Vector3(randomX, randomY), Quaternion.identity);
        enemy.SetActive(true);
        remainingSpawnTime = spawnDelay;
    }
}
