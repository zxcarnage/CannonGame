using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private FreezeSpawn _freezeSpawn;
    [SerializeField] private KillAll _killAll;

    [Space(10)] [Header("Sophisticator")] [SerializeField]
    private SophisticatorData _sophisticatorData;
    
    private NavMeshTriangulation _triangulation;
    private bool _freezed;

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable()
    {
        _freezeSpawn.OnBoosterActivated += Freeze;
        _killAll.OnBoosterActivated += KillAll;
    }

    private void OnDisable()
    {
        _freezeSpawn.OnBoosterActivated -= Freeze;
        _killAll.OnBoosterActivated -= KillAll;
    }

    private void Start()
    {
        _triangulation = NavMesh.CalculateTriangulation();
        StartCoroutine(Spawn());
        StartCoroutine(Sophistication());
    }

    private IEnumerator Sophistication()
    {
        while (!_freezed)
        {
            yield return new WaitForSeconds(_sophisticatorData.ChangingRate);
            _spawnDelay -= _sophisticatorData.SpawnerDelayDecrease;
        }
    }

    private IEnumerator Spawn()
    {
        while (!_freezed)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(_spawnDelay);
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

    private void Freeze(float freezeTime)
    {
        StartCoroutine(FreezeRoutine(freezeTime));
    }

    private void KillAll()
    {
        foreach (Transform child in transform)     
        {  
            child.gameObject.SetActive(false);   
        }   
    }

    private IEnumerator FreezeRoutine(float freezeTime)
    {
        _freezed = true;
        yield return new WaitForSeconds(freezeTime);
        _freezed = false;
    }
}
