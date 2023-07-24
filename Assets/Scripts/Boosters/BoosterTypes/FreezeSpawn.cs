using System;
using UnityEngine;

public class FreezeSpawn : Booster
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private float _freezeSpawnTime;
    public override void BoosterActivated()
    {
        _spawner.Freeze(_freezeSpawnTime);
    }
}