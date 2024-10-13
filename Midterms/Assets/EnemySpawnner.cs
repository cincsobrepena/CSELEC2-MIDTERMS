using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyPool enemyPool;
    public Transform player;
    public float spawnInterval = 2f;
    public float spawnRadius = 20f;
    public float minDistanceFromPlayer = 10f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = enemyPool.GetPooledEnemy();

        if (enemy != null)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            enemy.transform.position = spawnPosition;
            enemy.SetActive(true);

            enemy.GetComponent<Enemy>().player = player;
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition;
        do
        {
            Vector2 randomPoint = Random.insideUnitCircle * spawnRadius;
            spawnPosition = new Vector3(randomPoint.x, 0, randomPoint.y) + player.position;
        }
        while (Vector3.Distance(spawnPosition, player.position) < minDistanceFromPlayer);

        return spawnPosition;
    }
}
