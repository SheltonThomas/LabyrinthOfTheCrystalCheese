using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOptions;

    void Start()
    {
        GameVariables.GameLimit = 55;
        GameVariables.GameMode = 0;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void GameOptions()
    {
        gameOptions.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
