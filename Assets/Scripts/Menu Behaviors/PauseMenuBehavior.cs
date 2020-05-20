using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuBehavior : MonoBehaviour
{
    public GameObject pauseMenu;

    public static bool Paused { get; set; } = false;

    void Start()
    {
        pauseMenu.SetActive(Paused);
    }

    void Update()
    {
        if(Paused)
        {
            pauseMenu.SetActive(Paused);
        }
    }
    
    public void ResumeGame()
    {
        Paused = false;
        pauseMenu.SetActive(false);
    }

    public void QuitGame(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
