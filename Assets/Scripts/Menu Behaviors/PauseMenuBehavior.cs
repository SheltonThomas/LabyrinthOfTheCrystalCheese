using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;

    void Start()
    {
        //Starts with the pause menu not active.
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        //If game is pause, set pause menu to active.
        pauseMenu.SetActive(GameVariables.Paused);
        
    }
    
    //Resumes the game.
    public void ResumeGame()
    {
        GameVariables.Paused = false;
        pauseMenu.SetActive(false);
    }

    //Quits to the main menu.
    public void QuitGame(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
        GameVariables.Paused = false;
        GameVariables.CatScore = 0;
        GameVariables.MouseScore = 0;
    }

    public void Options()
    {
        gameObject.SetActive(false);
    }
}
