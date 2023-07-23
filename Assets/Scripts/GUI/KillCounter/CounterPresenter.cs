public class CounterPresenter
{
    private CounterModel _counterModel;
    private CounterView _counterView;

    public CounterPresenter(CounterView counterView)
    {
        _counterModel = new CounterModel();
        _counterView = counterView;
    }

    public void Enable()
    {
        _counterView.EnemyKilled += _counterModel.IncreaseNumber;
        _counterModel.NumberChanged += _counterView.UpdateNumber;
    }

    public void Disable()
    {
        _counterView.EnemyKilled -= _counterModel.IncreaseNumber;
        _counterModel.NumberChanged += _counterView.UpdateNumber;
    }
}
