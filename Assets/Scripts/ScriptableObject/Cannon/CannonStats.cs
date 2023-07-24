using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CannonStats", menuName = "Cannon Stats", order = 0)]
public class CannonStats : ScriptableObject
{
    [HideInInspector] public float BulletSpeed;
    [HideInInspector] public float BulletDamage;
    [HideInInspector] public float ShootDelay;    
    public float DefaultBulletSpeed;
    public float DefaultBulletDamage;
    public float DefaultShootDelay;

    private void OnEnable()
    {
        BulletDamage = DefaultBulletDamage;
        BulletSpeed = DefaultBulletSpeed;
        ShootDelay = DefaultShootDelay;
    }
}