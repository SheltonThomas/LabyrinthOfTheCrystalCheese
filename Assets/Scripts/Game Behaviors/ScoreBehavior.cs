using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehavior : MonoBehaviour
{
    [SerializeField]
    private Text mouseScoreText;

    [SerializeField]
    private Text catScoreText;

    void Update()
    {
        mouseScoreText.text = GameVariables.MouseScore.ToString();
        catScoreText.text = GameVariables.CatScore.ToString();
    }
}
