using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreBehavior : MonoBehaviour
{
    [SerializeField]
    private Text mouseScoreText;

    [SerializeField]
    private Text catScoreText;

    [SerializeField]
    private Text scoreLimitText;

    void Update()
    {
        mouseScoreText.text = GameVariables.MouseScore.ToString();
        catScoreText.text = GameVariables.CatScore.ToString();
        scoreLimitText.text = GameVariables.GameLimit.ToString();
    }
}
