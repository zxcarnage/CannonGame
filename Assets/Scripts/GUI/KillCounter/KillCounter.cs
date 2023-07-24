using System;
using TMPro;
using UnityEngine;
public class KillCounter : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _killsCounter;

    private void OnEnable()
    {
        _player.KillsUpdated += OnKillsUpdated;
    }

    private void OnDisable()
    {
        _player.KillsUpdated -= OnKillsUpdated;
    }

    private void OnKillsUpdated(int newKills)
    {
        _killsCounter.text = Convert.ToString(newKills);
    }
}