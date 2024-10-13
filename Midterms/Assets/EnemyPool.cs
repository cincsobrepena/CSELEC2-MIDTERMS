using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int poolSize = 10;

    private List<GameObject> pooledEnemies;

    void Start()
    {
        pooledEnemies = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false); 
            pooledEnemies.Add(enemy);
        }
    }

    public GameObject GetPooledEnemy()
    {
        foreach (GameObject enemy in pooledEnemies)
        {
            if (!enemy.activeInHierarchy)
            {
                return enemy;
            }
        }

        return null; 
    }

    public void ReturnToPool(GameObject enemy)
    {
        enemy.SetActive(false); 
    }
}
