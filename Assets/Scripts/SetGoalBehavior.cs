using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetGoalBehavior : MonoBehaviour
{
    //Used to make text say the right game mode.
    private string gameMode;
    [SerializeField]
    private Text goalText;

    //Used to make sure the next character that is inputted is a number.
    private float? previousNumber;
    [SerializeField]
    private InputField inputField;

    public int characterLimit;

    void Start()
    {
        //Sets the game mode to in the text.
        if (GameVariables.GameMode == GameMode.Points)
        {
            gameMode = "point";
        }
        if (GameVariables.GameMode == GameMode.Timed)
        {
            gameMode = "time";
        }
        //Writes the text.
        SetGoalText();
        //Sets character limit
        inputField.characterLimit = characterLimit;
    }

    //Writes the text telling the player to input limit.
    public void SetGoalText()
    {
        goalText.text = "Type the desired " + gameMode + " limit.";
    }

    //Checks to make sure the character inputted is an int.
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

    //Done after user presses enter.
    public void Confirm()
    {
        GameVariables.gameLimit = (float)previousNumber;
        //Change to goto game scene
        SceneManager.LoadScene(0);
    }
}
