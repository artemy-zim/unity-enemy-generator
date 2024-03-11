using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private SpawnPoint[] _spawnPoints;
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
        if(_enemy == null)
            throw new ArgumentNullException(nameof(_enemy));

        if(_spawnPoints == null)
            throw new ArgumentNullException(nameof(_spawnPoints));
    }

    private void Start()
    {
        StartCoroutine(OnSpawnEnemyCoroutine());
    }

    private IEnumerator OnSpawnEnemyCoroutine()
    {
        while (enabled)
        {
            SpawnPoint spawnPoint = GetSpawnPoint();

            spawnPoint.SpawnEnemy(_enemy);

            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private SpawnPoint GetSpawnPoint()
    {
        int minIndex = 0;

        return _spawnPoints[Random.Range(minIndex, _spawnPoints.Length)];
    }
}
