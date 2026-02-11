using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("Spawn Enemigos")]

    [Tooltip("Prefabs de enemigos")]
    [SerializeField] private GameObject[] _enemiesPrefab;
    [Tooltip("Numero de enemigos que van a spawnear")]
    [SerializeField] private int _enemiesToSpawn;
    [SerializeField] private Transform[] _spawnPoint;
    [Tooltip("Enemigo a spawnear")]
    [SerializeField] private int _enemyIndex;
    private BoxCollider _collider;

    void Awake()
    {
        _collider = GetComponent<BoxCollider>();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    // Update is called once per frame
    void Update()
    {

    }

    /*IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < _enemiesToSpawn; i++)
        {
            foreach (Transform spawn in _spawnPoint)
            {
                _enemyIndex = Random.Range(0, _enemiesPrefab.Length);
                Instantiate(_enemiesPrefab[_enemyIndex], spawn.position, spawn.rotation);

                yield return new WaitForSeconds(1);
            }

            yield return new WaitForSeconds(1);
        }
    }*/

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < _enemiesToSpawn; i++)
        {
            _enemyIndex = Random.Range(0, _enemiesPrefab.Length);

            Bounds bounds = _collider.bounds;

            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float spawnY = bounds.max.y;

            Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

            EnemyPool.Instance.SpawnEnemy(spawnPosition);

            yield return new WaitForSeconds(4f);
        }
    }
}
