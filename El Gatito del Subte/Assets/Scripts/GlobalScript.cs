using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public int playerScore;
    public Text score;

    // End player's game
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
    
    // Go back to main menu
    public void backToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    // Increase player's score
    public void increaseScore(int value)
    {
        playerScore++;
        score.text = "Score: " + Convert.ToString(playerScore);
    }
}
