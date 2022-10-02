using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public int playerScore;
    public Text score;
    public bool isPlayingIntro;
    public float currentTimeTimer;
    public Text currentTime;
    public int checkpointStatus;
    public bool runScoreTimer;
    public Text[] stationScores;

    void Update()
    {
        if (!isPlayingIntro && runScoreTimer)
        {
            currentTimeTimer += Time.deltaTime;
            currentTime.text = "Current time: " + currentTimeTimer.ToString("0.0");
        }
    }

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
        score.text = "Coins: " + Convert.ToString(playerScore);
    }

    // Switches current timer status
    public void switchCurrentTimer(string limitName)
    {
        switch (limitName)
        {
            case "EndSP":
                if (checkpointStatus == 0)
                {
                    runScoreTimer = true;
                    checkpointStatus++;
                }
                break;
            case "StartF":
                if (checkpointStatus == 1)
                {
                    runScoreTimer = false;
                    checkpointStatus++;
                    stationScores[0].text = "Station score: " + currentTimeTimer.ToString("0.0");
                }
                break;
            case "EndF":
                if (checkpointStatus == 2)
                {
                    runScoreTimer = true;
                    checkpointStatus++;
                    currentTimeTimer = 0;
                }
                break;
            case "StartC":
                if (checkpointStatus == 3)
                {
                    runScoreTimer = false;
                    checkpointStatus++;
                    stationScores[1].text = "Station score: " + currentTimeTimer.ToString("0.0");
                }
                break;
            default:
                throw new Exception("Unknown tunnel limit name");
        }
    }
}
