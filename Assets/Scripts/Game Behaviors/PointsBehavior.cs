using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsBehavior : MonoBehaviour
{
    public int pointsAmount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Mouse")
        {
            GameVariables.MouseScore += 10;

            if(GameVariables.MouseScore % 50 == 0)
            {
                GameVariables.MouseTraps++;
            }

            if(GameVariables.MouseScore == GameVariables.GameLimit && GameVariables.GameMode == GameMode.Score)
            {
                GameVariables.GameOver = true;
            }
            Destroy(gameObject);
        }

        if (other.name == "Cat")
        {
            GameVariables.CatScore += 10;

            if (GameVariables.CatScore % 100 == 0)
            {
                GameVariables.CatTraps++;
            }

            if (GameVariables.CatScore == GameVariables.GameLimit && GameVariables.GameMode == GameMode.Score)
            {
                GameVariables.GameOver = true;
            }
            Destroy(gameObject);
        }
    }
}
