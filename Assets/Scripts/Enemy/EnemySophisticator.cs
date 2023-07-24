using System;
using System.Collections;
using UnityEngine;

public class EnemySophisticator : MonoBehaviour
{
    [SerializeField] private SophisticatorData _sophisticatorData;
    [SerializeField] private SophisticatedStats _sophisticatedStats;
    [SerializeField] private DefaultStats defaultDefaultStats;

    private void Awake()
    {
        ResetSophisticatedStats();
    }

    public void Sophisticate()
    {
        StartCoroutine(SophisticateRoutine());
    }

    private IEnumerator SophisticateRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_sophisticatorData.ChangingRate);
            SophisticateEnemy();
        }
    }

    private void SophisticateEnemy()
    {
        _sophisticatedStats.SophisticatedHealth += _sophisticatorData.HealthIncrease;
        _sophisticatedStats.SophisticatedSpeed += _sophisticatorData.SpeedIncrease;
    }

    private void ResetSophisticatedStats()
    {
        _sophisticatedStats.SophisticatedHealth = defaultDefaultStats.DefaultHealth;
        _sophisticatedStats.SophisticatedSpeed = defaultDefaultStats.DefaultSpeed;
    }
}