using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField]
    private string MenuName;
    [SerializeField]
    private GameObject PauseMenu;

    public static bool GameIsPaused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log(GameIsPaused);
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }
    public void Resume()
    {
        Debug.Log("YES");
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        GameIsPaused = false;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(MenuName);
    }
    void Pause()
    {
        PauseMenu.SetActive(true);
        GameIsPaused = true;
        Time.timeScale = 0f;
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game...");
    }
}
