using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _direction;

    private void OnValidate()
    {
        _speed = Mathf.Clamp(_speed, 0, float.MaxValue);
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _direction, Space.World);
    }

    public void SetDirection(Vector3 direction)
    {
        if (direction == Vector3.zero)
            throw new ArgumentException(nameof(direction));

        _direction = direction.normalized;
    }
}
