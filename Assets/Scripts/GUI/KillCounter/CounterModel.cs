using System;

public class CounterModel
{
    private int _killedEnemies;

    public event Action<int> NumberChanged;

    public void IncreaseNumber()
    {
        NumberChanged?.Invoke(++_killedEnemies);
    }
}