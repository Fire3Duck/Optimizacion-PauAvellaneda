using UnityEngine;
using System.Collections.Generic;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool Instance;

    [Header("Enemy Pool")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int poolSize = 10;

    [SerializeField] private List<GameObject> pool = new List<GameObject>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        // Crear el pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform);
            enemy.SetActive(false);
            pool.Add(enemy);
        }
    }

    public GameObject SpawnEnemy(Vector3 position)
    {
        foreach (GameObject enemy in pool)
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.transform.position = position;
                enemy.transform.rotation = Quaternion.identity;
                enemy.SetActive(true);
                return enemy;
            }
        }

        // Opcional: crear más si se acaba el pool
        GameObject newEnemy = Instantiate(enemyPrefab, position, Quaternion.identity, transform);
        pool.Add(newEnemy);
        return newEnemy;
    }
}
