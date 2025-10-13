using UnityEngine;

public class EnemySpawner_TEAM26 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int enemiesPerSpawnPoint = 1;
    public float spawnInterval = 10f;
    public int increasePerWave = 1;
    public int maxEnemiesPerSpawnPoint = 3;

    private float timer = 0f;

    private void Start()
    {
        SpawnEnemies();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            enemiesPerSpawnPoint += Mathf.Min(enemiesPerSpawnPoint + increasePerWave, maxEnemiesPerSpawnPoint); // Increase number of enemies per spawn point
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        foreach(var sp in spawnPoints)
        {
            if (sp == null) continue;

            for (int i = 0; i < enemiesPerSpawnPoint; i++)
            {
                Vector3 offset = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
                Instantiate(enemyPrefab, sp.position + offset, Quaternion.identity);
            }
        }
    }
}
