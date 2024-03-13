using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private List<EnemySpawnPoint> _enemySpawnPoints;
    [SerializeField] private float _spawnDelay;

    private void OnEnable()
    {
        try
        {
            Validate();
        }
        catch (Exception e)
        {
            enabled = false;
            throw e;
        }
    }

    private void OnValidate()
    {
        _spawnDelay = Mathf.Clamp(_spawnDelay, 0, float.MaxValue);
    }

    private void Validate()
    {
        if (_enemies == null)
            throw new ArgumentNullException(nameof(_enemies));

        if (_enemySpawnPoints == null)
            throw new ArgumentNullException(nameof(_enemySpawnPoints));
    }

    private void Start()
    {
        StartCoroutine(OnSpawnEnemyCoroutine());
    }

    private IEnumerator OnSpawnEnemyCoroutine()
    {
        while (enabled)
        {
            Enemy enemy = GetEnemy();
            SpawnPoint spawnPoint = TryGetSpawnPoint(enemy.Type);

            spawnPoint.SpawnEnemy(enemy);

            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private SpawnPoint TryGetSpawnPoint(EnemyType type)
    {
        List<EnemySpawnPoint> enemySpawnPoints = _enemySpawnPoints.FindAll(enemySpawnPoint => enemySpawnPoint.Type == type);
        int minIndex = 0;

        if(enemySpawnPoints.Count == 0)
            throw new ArgumentException(nameof(_enemySpawnPoints));

        return enemySpawnPoints[Random.Range(minIndex, enemySpawnPoints.Count)].SpawnPoint;
    }

    private Enemy GetEnemy()
    {
        int minIndex = 0;

        return _enemies[Random.Range(minIndex, _enemies.Length)];
    }
}
