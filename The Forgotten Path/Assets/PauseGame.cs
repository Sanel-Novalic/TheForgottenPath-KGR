using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{

    public static bool GameIsPaused = false;

//public GameObject PauseMenuBehavior;

    void Update()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
                Debug.Log("KeyCode down: " + kcode);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        //PauseMenuBehavior.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Sandbox");
        GameIsPaused = false;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SideMenu");
    }
    void Pause()
    {
        //PauseMenuBehavior.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene("SideMenu");
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game...");
    }
}
