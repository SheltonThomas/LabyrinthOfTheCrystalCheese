using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode
{
    Timed,
    Points
}

public class GameVariables : MonoBehaviour
{
    //Point or time limit for the game.
    public static float gameLimit { get; set; }

    //Checks to see if game is paused.
    public static bool Paused { get; set; } = false;

    //Used for getting and setting the game mode.
    public static GameMode GameMode { get; set; }

    //Keeps track of the players' scores.
    public static int CatScore { get; set; } = 0;
    public static int MouseScore { get; set; } = 0;
}
