using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    private List<GameObject> activeEnemies = new List<GameObject>();
    private bool isWaveActive = false;

    void Update()
    {
        if (activeEnemies.Count == 0 && !isWaveActive)
        {
            SpawnWave();
        }
    }

    void SpawnWave()
    {
        isWaveActive = true;
        foreach (Transform spawnPoint in spawnPoints)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            activeEnemies.Add(enemy);
        }
    }

    public void RemoveEnemyFromList(GameObject enemy)
    {
        if (activeEnemies.Contains(enemy))
        {
            activeEnemies.Remove(enemy);
        }
        if (activeEnemies.Count == 0)
        {
            isWaveActive = false;
        }
    }
}
