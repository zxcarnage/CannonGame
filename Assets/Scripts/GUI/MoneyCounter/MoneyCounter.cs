using System;
using TMPro;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _killsCounter;

    private void OnEnable()
    {
        _player.MoneyUpdated += OnMoneyUpdated;
        OnMoneyUpdated(_player.Money);
    }

    private void OnDisable()
    {
        _player.MoneyUpdated -= OnMoneyUpdated;
    }

    private void OnMoneyUpdated(int newMoney)
    {
        _killsCounter.text = Convert.ToString(newMoney);
    }
}