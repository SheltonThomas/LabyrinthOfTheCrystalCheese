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
    public static float gameLimit { get; set; }

    public static bool Paused { get; set; } = false;

    public static GameMode GameMode { get; set; }
}
