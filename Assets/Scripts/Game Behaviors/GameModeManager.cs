using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject timerUI;

    [SerializeField]
    private Text ScoreUIText;
    [SerializeField]
    private Text ScoreUIText2;

    // Update is called once per frame
    void Update()
    {
        if(GameVariables.GameMode == GameMode.Score)
        {
            timerUI.SetActive(false);
            ScoreUIText.gameObject.SetActive(true);
            ScoreUIText2.gameObject.SetActive(true);
        }
        else
        {
            timerUI.SetActive(true);
            ScoreUIText.gameObject.SetActive(false);
            ScoreUIText2.gameObject.SetActive(false);
        }
    }
}
