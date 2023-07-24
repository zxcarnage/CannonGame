using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Player))]
public class PlayerLoser : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private PlayerRecords _records;

    private Player _player;
    private PlayerStats _playerStats;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _enemySpawner.AllEnemiesSpawned += Lose;
    }

    private void OnDisable()
    {
        _enemySpawner.AllEnemiesSpawned -= Lose;
    }

    private void Lose()
    {
        TrySaveRecord();
        ShowLoseScreen();
    }

    private void TrySaveRecord()
    {
        CreateRecord();
        if (_records.TopPlayers.Count == _records.RecordsSize)
            CompareScores();
        else if(!_records.TopPlayers.ContainsKey(_playerStats.Score))
            SaveScore();
        SaveToJSON();
    }

    private void CompareScores()
    {
        for (int i = 0; i < _records.TopPlayers.Count; i++)
        {
            var playerStat = _records.TopPlayers.ElementAt(i);
            if (playerStat.Key < _playerStats.Score)
            {
                ReplaceScore(_records.TopPlayers, playerStat.Key);
            }
        }
    }

    private void SaveScore()
    {
        _records.TopPlayers.Add(_playerStats.Score, _playerStats);
    }

    private void ReplaceScore(SortedDictionary<int, PlayerStats> topPlayers, int deletingStatKey)
    {
        _records.TopPlayers.Remove(deletingStatKey);
        _records.TopPlayers.Add(_playerStats.Score, _playerStats);
    }

    private void CreateRecord()
    {
        PlayerStats playerStats = new PlayerStats(_player.Score);
        _playerStats = playerStats;
    }

    private void ShowLoseScreen()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene(2);
    }

    private void SaveToJSON()
    {
        string jsonData = JsonConvert.SerializeObject(_records.TopPlayers, Formatting.Indented);
        File.WriteAllText(Application.persistentDataPath + "/playerRecords.json", jsonData);
    }
}