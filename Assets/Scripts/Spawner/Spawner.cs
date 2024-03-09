using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private GameObject _enemy;
    [SerializeField, Min(1)] private float _spawnDelay;

    private void Start()
    {
        StartCoroutine(OnSpawnCoroutine());
    }

    private IEnumerator OnSpawnCoroutine()
    {
        while (gameObject.activeSelf)
        {
            Spawn();

            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private void Spawn()
    {
        int minIndex = 0;

        SpawnPoint spawnPoint = _spawnPoints[Random.Range(minIndex, _spawnPoints.Length)];

        Instantiate(_enemy, spawnPoint.Position, spawnPoint.Rotation);
    }
}
