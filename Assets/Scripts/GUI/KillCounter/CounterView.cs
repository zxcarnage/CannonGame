using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class CounterView : MonoBehaviour
{
    [SerializeField] private EnemyContainer _container;

    private List<Enemy> _enemies;
    
    private TMP_Text _counter;
    private CounterPresenter _presenter;
    
    public event Action EnemyKilled;
    

    private void Start()
    {
        InitializeEnemies();
        _presenter.Enable();
        foreach (var enemy in _enemies)
        {
            enemy.Died += EnemyKilled.Invoke;
        }
    }

    private void InitializeEnemies()
    {
        _enemies = new List<Enemy>();
        _enemies = _container.GetEnemies();
    }

    private void Awake()
    {
        _presenter = new CounterPresenter(this);
        _counter = GetComponent<TMP_Text>();
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died -= EnemyKilled.Invoke;
        }
        _presenter.Disable();
    }

    public void UpdateNumber(int newNumber)
    {
        _counter.text = Convert.ToString(newNumber);
    }
}
