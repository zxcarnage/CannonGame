using UnityEngine;

public class BulletSpawner : ObjectPool
{
    [SerializeField] private CannonStats _cannonStats;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
            TrySpawn();
        }
    }

    private void TrySpawn()
    {
        if (_elapsedTime >= _cannonStats.ShootDelay)
        {
            Spawn();
            _elapsedTime = 0;
        }
    }

    private void Spawn()
    {
        if (TryGetElement(out GameObject bullet))
        {
            LocateBullet(bullet);
            SetShootDirection(bullet);
            bullet.SetActive(true);
        }
    }

    private void SetShootDirection(GameObject bulletObject)
    {
        if (bulletObject.TryGetComponent(out Bullet bullet))
        {
            bullet.ShootDirection = transform.right.normalized;
        }
    }

    private void LocateBullet(GameObject bullet)
    {
        bullet.transform.position = transform.position;
    }
}
