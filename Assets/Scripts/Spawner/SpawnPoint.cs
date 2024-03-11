using System;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;

    public void SpawnEnemy(Enemy enemy)
    {
        if(enemy == null)
            throw new ArgumentNullException(nameof(enemy));

        Enemy newEnemy = Instantiate(enemy, transform.position, Quaternion.LookRotation(_direction));
        newEnemy.SetDirection(_direction);
    }
}
