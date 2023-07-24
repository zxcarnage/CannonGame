using System;
using UnityEngine;

public class PauseInput : MonoBehaviour
{
    [SerializeField] private Menu _main;
    [SerializeField] private GameObject _pauseMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            
            _main.OpenPanel(_pauseMenu);
        }
    }
}
