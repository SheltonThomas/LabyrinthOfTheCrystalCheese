using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverMenu;

    [SerializeField]
    private Text winnerText;
    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        gameOverMenu.SetActive(GameVariables.GameOver);
        if(gameOverMenu.activeInHierarchy)
        {
            if(GameVariables.MouseScore > GameVariables.CatScore)
            {
                winnerText.text = "Mouse";
            }
            else
            {
                winnerText.text = "Cat";
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(2);
        GameVariables.GameOver = false;
        GameVariables.CatScore = 0;
        GameVariables.MouseScore = 0;
        GameVariables.CatTraps = 0;
        GameVariables.MouseTraps = 0;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        GameVariables.GameOver = false;
        GameVariables.CatScore = 0;
        GameVariables.MouseScore = 0;
        GameVariables.CatTraps = 0;
        GameVariables.MouseTraps = 0;
    }
}
