using System;

public interface IDataBooster <T>
{
    public event Action<T> OnBoosterActivated;
}
