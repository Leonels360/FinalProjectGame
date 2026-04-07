using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    // Put the exact name of your game scene here
    public string gameSceneName = "SampleScene";

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}