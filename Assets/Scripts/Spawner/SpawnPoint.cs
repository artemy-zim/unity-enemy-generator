using UnityEngine;

[RequireComponent (typeof(Transform))]
public class SpawnPoint : MonoBehaviour
{
    [SerializeField, Range(0, 359)] private float _rotationAngleY;
    
    private Vector3 _position;

    public Vector3 Position => _position;
    public Quaternion Rotation => Quaternion.Euler(0, _rotationAngleY, 0);

    private void Awake()
    {
        _position = GetComponent<Transform>().position;
    }
}
