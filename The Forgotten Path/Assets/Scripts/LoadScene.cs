using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour { 
    public void OnMouseButton() 
    {
        SceneManager.LoadScene("Game");
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
};
