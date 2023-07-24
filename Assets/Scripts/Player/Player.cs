using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerBoosterActivator))]
public class Player : MonoBehaviour
{
    [SerializeField] private EnemyContainer _enemyContainer;

    private int _money;
    private int _killAmount;
    private List<Enemy> _enemies;
    private PlayerBoosterActivator _activator;

    public event Action<int> KillsUpdated;
    public event Action<int> MoneyUpdated;
    public int Money => _money;

    private void Awake()
    {
        _activator = GetComponent<PlayerBoosterActivator>();
    }

    private void Start()
    {
        InitializeEnemies();
        foreach (var enemy in _enemies)
        {
            enemy.Died += OnEnemyKilled;
        }
    }
    
    private void InitializeEnemies()
    {
        _enemies = new List<Enemy>();
        _enemies = _enemyContainer.GetEnemies();
    }

    public void AddMoney(int money)
    {
        _money += money;
        MoneyUpdated?.Invoke(_money);
    }

    private void OnEnemyKilled()
    {
        _killAmount++;
        AddMoney(1);
        KillsUpdated?.Invoke(_killAmount);
    }

    public bool TryBuy(int price)
    {
        if (_money < price)
            return false;
        AddMoney(-price);
        return true;
    }

    public void AddBooster(Booster booster)
    {
        _activator.AddBooster(booster);
    }
}
