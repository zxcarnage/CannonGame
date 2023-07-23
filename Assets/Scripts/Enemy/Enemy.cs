using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(EnemySophisticator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private SophisticatedStats _sophisticatedStats;

    public event Action Died;

    private float _health;
    private float _speed;
    private EnemyMover _mover;
    private EnemySophisticator _sophisticator;
    private NavMeshAgent _agent;

    public NavMeshAgent Agent => _agent;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _agent = GetComponent<NavMeshAgent>();
        _sophisticator = GetComponent<EnemySophisticator>();
    }

    public void Spawned()
    {
        ResetStats();
        _mover.StartPatroul(_speed);
        _sophisticator.Sophisticate();
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;
        TryDie();
    }
    

    private void TryDie()
    {
        if (_health <= 0)
            Die();
    }

    private void ResetStats()
    {
        _health = _sophisticatedStats.SophisticatedHealth;
        _speed = _sophisticatedStats.SophisticatedSpeed;
    }
    
    private void Die()
    {
        Debug.Log("Умер " + this);
        Died?.Invoke();
        gameObject.SetActive(false);
    }
}