using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsBehavior : MonoBehaviour
{
    public int pointsAmount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Mouse")
        {
            GameVariables.MouseScore += 10;
            if(GameVariables.MouseScore == GameVariables.GameLimit && GameVariables.GameMode == GameMode.Score)
            {
                //Add GameOver Screen
            }
            Destroy(gameObject);
        }

        if (other.tag == "Cat")
        {
            GameVariables.CatScore += 10;
            if (GameVariables.CatScore == GameVariables.GameLimit && GameVariables.GameMode == GameMode.Score)
            {
                //Add GameOver Screen
            }
            Destroy(gameObject);
        }
    }
}
