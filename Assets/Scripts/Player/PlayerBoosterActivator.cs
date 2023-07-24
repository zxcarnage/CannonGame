using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoosterActivator : MonoBehaviour
{
    private Player _player;
    private Queue<Booster> _boosters;

    private void Start()
    {
        _boosters = new Queue<Booster>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryActivateBoosters();
        }
    }

    public void AddBooster(Booster booster)
    {
        _boosters.Enqueue(booster);
    }

    private void TryActivateBoosters()
    {
        if (_boosters.Count == 0)
            return;
        if (Time.timeScale == 0)
            return;
        while (_boosters.Count != 0)
        {
            _boosters.Dequeue().BoosterActivated();
        }
    }
}