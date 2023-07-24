using System.Collections.Generic;
using UnityEngine;

public class KillAll : Booster
{
    [SerializeField] private EnemyContainer _enemyContainer;

    private List<Enemy> _enemies;
    public override void BoosterActivated()
    {
        GetEnemies();
        KillAllEnemies();
    }

    private void KillAllEnemies()
    {
        foreach (var enemy in _enemies)
        {
            if(enemy.isActiveAndEnabled)
                enemy.ApplyDamage(float.MaxValue);
        }
    }

    private void GetEnemies()
    {
        _enemies = new List<Enemy>();
        _enemies = _enemyContainer.GetEnemies();
    }
}