using System;

public class KillAll : Booster, ICommonBooster
{
    public event Action OnBoosterActivated;

    public override void Boost()
    {
        OnBoosterActivated?.Invoke();
    }
}