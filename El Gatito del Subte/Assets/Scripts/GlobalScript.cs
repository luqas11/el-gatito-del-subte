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
    public bool allowSpawn = true;
    public GameObject spawnPauseIcon;
    public GameObject canvas;
    public GameObject screenNotification;

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
        score.text = Convert.ToString(playerScore);
    }

    // Sets if train spawn is allowed
    public void setTrainSpawn(bool allow)
    {
        allowSpawn = allow;
        spawnPauseIcon.SetActive(!allow);
    }

    // Shows a text notification overlay, that disappears after some time
    public void showNotification(string text)
    {
        GameObject notification = Instantiate(screenNotification);
        notification.transform.SetParent(canvas.transform, false);
        notification.GetComponent<TextNotification>().textElement.text = text;
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
                    showNotification("Leaving San Pedrito station");
                }
                break;
            case "StartF":
                if (checkpointStatus == 1)
                {
                    runScoreTimer = false;
                    checkpointStatus++;
                    stationScores[0].text = "Station score: " + currentTimeTimer.ToString("0.0");
                    showNotification("Arriving to Flores station after " + currentTimeTimer.ToString("0.0") + "s");
                }
                break;
            case "EndF":
                if (checkpointStatus == 2)
                {
                    runScoreTimer = true;
                    checkpointStatus++;
                    currentTimeTimer = 0;
                    showNotification("Leaving Flores station");
                }
                break;
            case "StartC":
                if (checkpointStatus == 3)
                {
                    runScoreTimer = false;
                    checkpointStatus++;
                    stationScores[1].text = "Station score: " + currentTimeTimer.ToString("0.0");
                    showNotification("Arriving to Carabobo station after " + currentTimeTimer.ToString("0.0") + "s");
                }
                break;
            case "EndC":
                if (checkpointStatus == 4)
                {
                    runScoreTimer = true;
                    checkpointStatus++;
                    currentTimeTimer = 0;
                    showNotification("Leaving Carabobo station");
                }
                break;
            case "StartP":
                if (checkpointStatus == 5)
                {
                    runScoreTimer = false;
                    checkpointStatus++;
                    stationScores[2].text = "Station score: " + currentTimeTimer.ToString("0.0");
                    showNotification("Arriving to Puan station after " + currentTimeTimer.ToString("0.0") + "s");
                }
                break;
            case "EndP":
                if (checkpointStatus == 6)
                {
                    runScoreTimer = true;
                    checkpointStatus++;
                    currentTimeTimer = 0;
                    showNotification("Leaving Puan station");
                }
                break;
            case "StartPJ":
                if (checkpointStatus == 7)
                {
                    runScoreTimer = false;
                    checkpointStatus++;
                    stationScores[3].text = "Station score: " + currentTimeTimer.ToString("0.0");
                    showNotification("Arriving to Primera Junta station after " + currentTimeTimer.ToString("0.0") + "s");
                }
                break;
            default:
                throw new Exception("Unknown tunnel limit name");
        }
    }
}
