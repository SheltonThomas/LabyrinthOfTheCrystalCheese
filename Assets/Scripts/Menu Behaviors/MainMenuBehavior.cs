using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBehavior : MonoBehaviour
{
    public void PlayGame(int gameMode)
    {
        GameVariables.GameMode = (GameMode)gameMode;
    }
}
