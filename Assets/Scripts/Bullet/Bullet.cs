using System;
using UnityEngine;

[RequireComponent(typeof(BulletMover))]
public class Bullet: MonoBehaviour
{
    [SerializeField] private CannonStats _cannonStats;
    
    private BulletMover _mover;
    private float _elapsedTime;
    public Vector3 ShootDirection { private get; set; }
    
    private void Awake()
    {
        _mover = GetComponent<BulletMover>();
    }

    private void OnEnable()
    {
        _mover.Move(ShootDirection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        HandleCollision(collision);
    }

    private void HandleCollision(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
            enemy.ApplyDamage(_cannonStats.BulletDamage);
        Destroy();
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
}
