using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _shootPower;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        _rigidbody.velocity = direction * _shootPower;
    }
}
