using System;
using UnityEngine;

[Serializable]
public struct EnemySpawnPoint
{
    [SerializeField] private EnemyType _type;
    [SerializeField] private SpawnPoint _spawnPoint;

    public EnemyType Type => _type;
    public SpawnPoint SpawnPoint => _spawnPoint;
}
