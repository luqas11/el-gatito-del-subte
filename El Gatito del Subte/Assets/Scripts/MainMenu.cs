using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Starts gameplay scene
    public void play()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    // Completely close game
    public void quit()
    {
        Application.Quit();
    }
}
