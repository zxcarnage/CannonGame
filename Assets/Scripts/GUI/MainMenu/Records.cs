using System;
using System.Linq;
using UnityEngine;

public class Records : MonoBehaviour
{
    [SerializeField] private RecordView _template;
    [SerializeField] private GameObject _recordsContainer;

    [SerializeField] private PlayerRecords _records;
    
    private void OnEnable()
    {
        InitializeRecords();
    }

    private void InitializeRecords()
    {
        for (int i = _records.TopPlayers.Count - 1; i >= 0 ; i--)
        {
            AddItem(_records.TopPlayers.ElementAt(i).Key);
        }
    }

    private void AddItem(int record)
    {
        var view = Instantiate(_template, _recordsContainer.transform);

        view.Render(record);
    }

    private void RemoveItems()
    {
        for (int i = 0; i < _recordsContainer.transform.childCount; i++)
        {
            Destroy(_recordsContainer.transform.GetChild(i).gameObject);
        }
    }

    private void OnDisable()
    {
        RemoveItems();
    }
}