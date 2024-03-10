using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _spawnDelay;

    private SpawnPoint[] _spawnPoints;

    private void Awake()
    {
        _spawnPoints = transform.GetComponentsInChildren<SpawnPoint>();        
    }

    private void OnValidate()
    {
        _spawnDelay = Mathf.Clamp(_spawnDelay, 0, float.MaxValue);
    }

    private void OnEnable()
    {
        if(_enemy == null)
        {
            enabled = false;
            throw new ArgumentNullException(nameof(_enemy));
        }
    }

    private void Start()
    {
        StartCoroutine(OnSpawnEnemyCoroutine());
    }

    private IEnumerator OnSpawnEnemyCoroutine()
    {
        while (gameObject.activeSelf)
        {
            SpawnPoint spawnPoint = GetSpawnPoint();

            Enemy enemy = Instantiate(_enemy, spawnPoint.transform.position, Quaternion.LookRotation(spawnPoint.Direction));
            enemy.SetDirection(spawnPoint.Direction);

            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private SpawnPoint GetSpawnPoint()
    {
        int minIndex = 0;

        return _spawnPoints[Random.Range(minIndex, _spawnPoints.Length)];
    }
}
