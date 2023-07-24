using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletMover : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction, float shootSpeed)
    {
        _rigidbody.velocity = direction * shootSpeed;
    }
}
