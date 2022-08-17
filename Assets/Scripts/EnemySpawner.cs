using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> Enemies = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnEnemy(5f));        
        StartCoroutine(SpawnEnemy(2f));        
        StartCoroutine(SpawnEnemy(3f));        
        StartCoroutine(SpawnEnemy(5f));
        StartCoroutine(SpawnEnemy(6f));
    }

    IEnumerator SpawnEnemy(float spawnDelay)
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnDelay);
            Instantiate(Enemies[Random.Range(0, Enemies.Count)], new Vector2(Random.Range(-20f, 20f), Random.Range(-20f, 20f)), Quaternion.identity);
        }
    }
}
