using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public int lives;

    public void LoseLife()
    {
        lives--;
        if (lives == 0)
        {
            //Game over logic
        }
    }
}
