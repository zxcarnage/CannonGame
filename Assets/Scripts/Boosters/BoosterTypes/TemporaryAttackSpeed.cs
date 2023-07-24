using System;
using System.Collections;
using UnityEngine;

public class TemporaryAttackSpeed : Booster, IBoosterTimable
{
    [SerializeField] private float _boostSeconds;
    [SerializeField] private CannonStats _cannonStats;

    public override void BoosterActivated()
    {
        StartCoroutine(ActivateBoosterRoutine());
    }

    private IEnumerator ActivateBoosterRoutine()
    {
        _cannonStats.ShootDelay /= 2;
        yield return new WaitForSeconds(_boostSeconds);
        BoosterEnded();
    }

    public void BoosterEnded()
    {
        _cannonStats.ShootDelay *= 2;
    }
}
