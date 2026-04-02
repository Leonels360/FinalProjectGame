using UnityEngine;
using UnityEngine.SceneManagement; 


public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel; 
    public GameObject winPanel; 

    public void GameOver()
    {
        gameOverPanel.SetActive(true); 

        Time.timeScale = 0f;  
    }


    public void Win()
    {
        winPanel.SetActive(true); 
        Time.timeScale  -= 0f; 
    }

    public void Restart()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
    
}
