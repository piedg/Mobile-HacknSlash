using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float SpawnDelay;
    [SerializeField] List<GameObject> Enemies = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnEnemy());        
        StartCoroutine(SpawnEnemy());        
        StartCoroutine(SpawnEnemy());        
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            Instantiate(Enemies[Random.Range(0, Enemies.Count)], new Vector2(Random.Range(-20f, 20f), Random.Range(-20f, 20f)), Quaternion.identity);
            yield return new WaitForSeconds(SpawnDelay);
        }
    }
}
