using System;
using UnityEngine;

public class TemporaryAttackSpeed : Booster, IDataBooster<float>
{
    [SerializeField] private float _boostSeconds;
    
    public event Action<float> OnBoosterActivated;

    public override void Boost()
    {
        OnBoosterActivated.Invoke(_boostSeconds);
    }
}
