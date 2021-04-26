using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour { 
    public void OnMouseButton() 
    {
        SceneManager.LoadScene("Sandbox");
    } 
};
