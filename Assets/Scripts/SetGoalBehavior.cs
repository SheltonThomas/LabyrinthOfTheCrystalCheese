using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetGoalBehavior : MonoBehaviour
{
    private string gameMode;
    [SerializeField]
    private Text goalText;

    private float? previousNumber;
    [SerializeField]
    private InputField inputField;

    void Start()
    {
        GameVariables.GameMode = GameMode.Points;

        if (GameVariables.GameMode == GameMode.Points)
        {
            gameMode = "point";
        }
        if (GameVariables.GameMode == GameMode.Timed)
        {
            gameMode = "time";
        }
        SetGoalText();
        inputField.characterLimit = 6;
    }

    public void SetGoalText()
    {
        goalText.text = "Type the desired " + gameMode + " limit.";
    }

    public void CheckForCharacter()
    {
        if(inputField.text.Length == 0)
        {
            previousNumber = null;
            return;
        }

        char characterToCheck = inputField.text[inputField.text.Length - 1];
        int intCheck;
        if (int.TryParse(characterToCheck.ToString(), out intCheck))
        {
            previousNumber = int.Parse(inputField.text);
        }
        else
        {
            inputField.text = previousNumber.ToString();
        }
    }

    public void Confirm()
    {
        GameVariables.gameLimit = (float)previousNumber;
        //Change to goto game scene
        SceneManager.LoadScene(0);
    }
}
