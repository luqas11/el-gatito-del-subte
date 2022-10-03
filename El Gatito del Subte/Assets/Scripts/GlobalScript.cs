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
    public StationReward[] stationCoinIndicators;
    public bool allowSpawn = true;
    public GameObject spawnPauseIcon;
    public GameObject canvas;
    public GameObject screenNotification;
    public bool isPaused = false;
    public GameObject pauseScreen;
    public Text gameOverScoreIndicator;
    public GameObject trainSpawnIndicators;
    public bool trainIndicatorsActive = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            setPause(!isPaused);
        }
        if (!isPlayingIntro && runScoreTimer)
        {
            currentTimeTimer += Time.deltaTime;
            currentTime.text = currentTimeTimer.ToString("0.0") + "s";
        }
    }

    // Show or hide the train indicators
    public void setTrainIndicatorsVisibility(bool isActive)
    {
        trainIndicatorsActive = isActive;
    }

    // Pauses the game and show a pause screen
    public void setPause(bool pause)
    {
        isPaused = pause;
        pauseScreen.SetActive(isPaused);
        Time.timeScale = Convert.ToSingle(!isPaused);
    }

    // End player's game
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        gameOverScoreIndicator.text = "SCORE: " + playerScore;
    }
    
    // Goes back to the main menu
    public void backToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    // Increase player's score by the given value
    public void increaseScore(int value)
    {
        playerScore += value;
        score.text = Convert.ToString(playerScore);
    }

    // Sets if train spawn is allowed or not
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

    // Switches current station timer status
    public void switchCurrentTimer(string limitName)
    {
        switch (limitName)
        {
            case "EndSP":
                if (checkpointStatus == 0)
                {
                    runScoreTimer = true;
                    checkpointStatus++;
                    showNotification("Entering next tunnel");
                }
                break;
            case "StartF":
                if (checkpointStatus == 1)
                {
                    runScoreTimer = false;
                    checkpointStatus++;
                    int coinAmount = stationCoinIndicators[0].setCoinValues((int)currentTimeTimer);
                    showNotification("Arriving to station after " + currentTimeTimer.ToString("0.0") + "s. A reward of " + coinAmount + " coins is available.");
                }
                break;
            case "EndF":
                if (checkpointStatus == 2)
                {
                    runScoreTimer = true;
                    checkpointStatus++;
                    currentTimeTimer = 0;
                    showNotification("Entering next tunnel");
                }
                break;
            case "StartC":
                if (checkpointStatus == 3)
                {
                    runScoreTimer = false;
                    checkpointStatus++;
                    int coinAmount = stationCoinIndicators[1].setCoinValues((int)currentTimeTimer);
                    showNotification("Arriving to station after " + currentTimeTimer.ToString("0.0") + "s. A reward of " + coinAmount + " coins is available.");
                }
                break;
            case "EndC":
                if (checkpointStatus == 4)
                {
                    runScoreTimer = true;
                    checkpointStatus++;
                    currentTimeTimer = 0;
                    showNotification("Entering next tunnel");
                }
                break;
            case "StartP":
                if (checkpointStatus == 5)
                {
                    runScoreTimer = false;
                    checkpointStatus++;
                    int coinAmount = stationCoinIndicators[3].setCoinValues((int)currentTimeTimer);
                    showNotification("Arriving to station after " + currentTimeTimer.ToString("0.0") + "s. A reward of " + coinAmount + " coins is available.");
                }
                break;
            case "EndP":
                if (checkpointStatus == 6)
                {
                    runScoreTimer = true;
                    checkpointStatus++;
                    currentTimeTimer = 0;
                    showNotification("Entering next tunnel");
                }
                break;
            case "StartPJ":
                if (checkpointStatus == 7)
                {
                    runScoreTimer = false;
                    checkpointStatus++;
                    int coinAmount = stationCoinIndicators[3].setCoinValues((int)currentTimeTimer);
                    showNotification("Arriving to station after " + currentTimeTimer.ToString("0.0") + "s. A reward of " + coinAmount + " coins is available.");
                }
                break;
            default:
                throw new Exception("Unknown tunnel limit name");
        }
    }
}
