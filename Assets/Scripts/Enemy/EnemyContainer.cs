using System.Collections.Generic;
using UnityEngine;

public class EnemyContainer : MonoBehaviour
{
    public List<Enemy> GetEnemies()
    {
        var enemies = new List<Enemy>();
        for (int i = 0; i < transform.childCount; i++)
        {
            enemies.Add(transform.GetChild(i).GetComponent<Enemy>());
        }

        return enemies;
    }
}
