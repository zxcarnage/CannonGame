using UnityEngine;

[CreateAssetMenu(fileName = "CannonStats", menuName = "Cannon Stats", order = 0)]
public class CannonStats : ScriptableObject
{
    public float BulletSpeed;
    public float BulletDamage;
    public float ShootDelay;
}