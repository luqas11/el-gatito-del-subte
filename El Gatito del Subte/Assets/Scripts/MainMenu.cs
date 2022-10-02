using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public bool showFadeOut;
    public float timer;
    public float fadeOutTime;
    public Image fadeOutPanel;

    public void Update()
    {
        if (showFadeOut)
        {
            timer += Time.deltaTime;
            fadeOutPanel.color = new Color(0, 0, 0, timer / fadeOutTime);
            if (timer > fadeOutTime * 1.5)
            {
                SceneManager.LoadScene(1, LoadSceneMode.Single);
            }
        }
    }

    // Starts transition to Gameplay scene
    public void play()
    {
        showFadeOut = true;
    }

    // Completely close game
    public void quit()
    {
        Application.Quit();
    }
}
