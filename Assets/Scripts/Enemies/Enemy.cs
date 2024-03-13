using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyType _type;
    [SerializeField] private float _speed;

    private Target _target;

    public EnemyType Type => _type;

    private void OnValidate()
    {
        _speed = Mathf.Clamp(_speed, 0, float.MaxValue);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
        transform.LookAt(_target.transform.position);
    }

    public void SetTarget(Target target)
    {
        if (target == null)
            throw new ArgumentException(nameof(target));

        _target = target;
    }
}
