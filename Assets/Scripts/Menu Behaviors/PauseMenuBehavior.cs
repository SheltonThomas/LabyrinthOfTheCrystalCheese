using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuBehavior : MonoBehaviour
{
    public GameObject pauseMenu;

    void Start()
    {
        pauseMenu.SetActive(GameVariables.Paused);
    }

    void Update()
    {
        if(GameVariables.Paused)
        {
            pauseMenu.SetActive(GameVariables.Paused);
        }
    }
    
    public void ResumeGame()
    {
        GameVariables.Paused = false;
        pauseMenu.SetActive(false);
    }

    public void QuitGame(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
