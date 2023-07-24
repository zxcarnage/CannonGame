using System;
using TMPro;
using UnityEngine;

public class RecordView : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    public void Render(int score)
    {
        _scoreText.text = Convert.ToString(score);
    }
}