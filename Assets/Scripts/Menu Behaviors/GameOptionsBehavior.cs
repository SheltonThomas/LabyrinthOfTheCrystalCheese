using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOptionsBehavior : MonoBehaviour
{
    //Used to make text say the right game mode.
    private string gameMode;
    [SerializeField]
    private Text goalText;
    [SerializeField]
    private Text currentGameMode;
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private Text currentGameLimit;
    [SerializeField]
    private Text gameLimit;

    //Used to make sure the next character that is inputted is a number.
    private float? previousNumber;
    [SerializeField]
    private InputField inputField;

    public int characterLimit;

    void Start()
    {
        previousNumber = GameVariables.GameLimit;
        //Sets the game mode to in the text.
        gameMode = GameVariables.GameMode.ToString();
        //Writes the text.
        SetGoalText();
        //Sets character limit
        inputField.characterLimit = characterLimit;
        gameObject.SetActive(false);
    }

    void Update()
    {
        SetGoalText();
        SetCurrentLimitText();
        currentGameMode.text = GameVariables.GameMode.ToString();
        currentGameLimit.text = GameVariables.GameLimit.ToString();
    }

    //Writes the text telling the player to input limit.
    private void SetGoalText()
    {
        goalText.text = "Type the desired " + gameMode + " limit.";
    }

    private void SetCurrentLimitText()
    {
        goalText.text = "Current " + gameMode + " limit:";
    }

    //Checks to make sure the character inputted is an int.
    private void CheckForCharacter()
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

    public void Timer()
    {
        GameVariables.GameMode = (GameMode)0;
    }

    public void Score()
    {
        GameVariables.GameMode = (GameMode)1;
    }

    public void Confirm()
    {
        if (previousNumber != null)
        {
            GameVariables.GameLimit = (float)previousNumber;
        }
        else
        {
            if (GameVariables.GameMode == 0)
            {
                GameVariables.GameLimit = 55;
            }

            else if (GameVariables.GameMode == (GameMode)1)
            {
                GameVariables.GameLimit = 55;
            }
        }
    }

    public void Back()
    {
        menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
