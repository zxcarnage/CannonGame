using System;
using UnityEngine;

public class FreezeSpawn : Booster, IDataBooster<float>
{
    [SerializeField] private float _freezeTime;
    public event Action<float> OnBoosterActivated;
    
    public override void Boost()
    {
        OnBoosterActivated.Invoke(_freezeTime);
    }
}