using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBehavior : MonoBehaviour
{
    public SetGoalBehavior setGoalBehavior;

    public void PlayGame(int gameMode)
    {
        GameVariables.GameMode = (GameMode)gameMode;
        setGoalBehavior.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
