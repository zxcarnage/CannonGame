using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private float _spawnDelay;

    [Space(10)] [Header("Sophisticator")] [SerializeField]
    private SophisticatorData _sophisticatorData;
    
    private NavMeshTriangulation _triangulation;
    private float _freezeTime;

    private void Awake()
    {
        _freezeTime = 0;
        Initialize();
    }

    private void Start()
    {
        _triangulation = NavMesh.CalculateTriangulation();
        StartCoroutine(Spawn());
        StartCoroutine(Sophistication());
    }

    private IEnumerator Sophistication()
    {
        while (true)
        {
            yield return new WaitForSeconds(_sophisticatorData.ChangingRate + _freezeTime);
            _spawnDelay -= _sophisticatorData.SpawnerDelayDecrease;
        }
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(_spawnDelay + _freezeTime);
        }
    }

    private void SpawnEnemy()
    {
        if (TryGetElement(out GameObject poolObject))
        {
            poolObject.SetActive(true);
            Enemy enemy = poolObject.GetComponent<Enemy>();
            LocateEnemy(enemy);
            enemy.Spawned();
        }
    }

    private void LocateEnemy(Enemy enemy)
    {
        int VertexIndex = Random.Range(0, _triangulation.vertices.Length);

        if (NavMesh.SamplePosition(_triangulation.vertices[VertexIndex], out NavMeshHit hit, 2f, 1))
        {
            enemy.Agent.Warp(hit.position);
        }
    }

    public void Freeze(float freezeTime)
    {
        StartCoroutine(FreezeRoutine(freezeTime));
    }

    private IEnumerator FreezeRoutine(float freezeTime)
    {
        _freezeTime = freezeTime;
        yield return new WaitForSeconds(freezeTime);
        _freezeTime = 0;
    }
}
