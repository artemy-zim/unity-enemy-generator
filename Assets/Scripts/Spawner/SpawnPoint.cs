using System;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Target _target;

    private void OnEnable()
    {
        if (_target == null)
        {
            enabled = false;
            throw new ArgumentNullException(nameof(_target));
        }
    }

    public void SpawnEnemy(Enemy enemy)
    {
        if (enemy == null)
            throw new ArgumentNullException(nameof(enemy));

        Enemy newEnemy = Instantiate(enemy, transform.position, Quaternion.LookRotation(_target.transform.position));
        newEnemy.SetTarget(_target);
    }
}
