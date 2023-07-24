using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OpenPanel(GameObject panel)
    {
        Time.timeScale = 0f;
        ChangeCursorState();
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        Time.timeScale = 1f;
        ChangeCursorState();
        panel.SetActive(false);
    }

    private void ChangeCursorState()
    {
        if (Time.timeScale > 0.9f)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void Restart()
    {
        if (Time.timeScale < 0.1f)
            Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void ExitInMainMenu()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

}