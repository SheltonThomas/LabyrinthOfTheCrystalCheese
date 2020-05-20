using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        MainMenuBehavior.GameMode = GameMode.Points;

        if (MainMenuBehavior.GameMode == GameMode.Points)
        {
            gameMode = "point";
        }
        if (MainMenuBehavior.GameMode == GameMode.Timed)
        {
            gameMode = "time";
        }
        SetGoalText();
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
}
