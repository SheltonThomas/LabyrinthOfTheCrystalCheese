using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode
{
    Timed,
    Points
}

public class MainMenuBehavior : MonoBehaviour
{
    public static GameMode GameMode { get; set; }

    public void PlayGame(int gameMode)
    {
        GameMode = (GameMode)gameMode;
    }
}
