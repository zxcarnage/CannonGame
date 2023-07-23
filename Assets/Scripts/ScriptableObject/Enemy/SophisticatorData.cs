using UnityEngine;

[CreateAssetMenu(fileName = "EnemySophisticatorData", menuName = "Enemy Sophisticator Data", order = 0)]
public class SophisticatorData : ScriptableObject
{
    public float SpawnerDelayDecrease;
    public float HealthIncrease;
    public float SpeedIncrease;
    public float ChangingRate;
}