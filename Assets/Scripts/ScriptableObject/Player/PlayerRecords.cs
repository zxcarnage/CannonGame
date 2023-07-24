using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

[CreateAssetMenu(fileName = "Records", menuName = "Menu/Records", order = 0)]
public class PlayerRecords : ScriptableObject
{
    public SortedDictionary<int, PlayerStats> TopPlayers;

    private void OnEnable()
    {
        LoadFromJSON();
    }

    private void LoadFromJSON()
    {
        string path = Application.persistentDataPath + "/playerRecords.json";

        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            TopPlayers = JsonConvert.DeserializeObject<SortedDictionary<int, PlayerStats>>(jsonData);
        }
        else
            TopPlayers = new SortedDictionary<int, PlayerStats>();
    }

    public int RecordsSize;
}