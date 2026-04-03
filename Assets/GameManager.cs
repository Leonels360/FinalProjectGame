using UnityEngine;
using UnityEngine.SceneManagement; 


public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel; 
    public GameObject winPanel;


    void Start()
    {
        Time.timeScale = 1f; 

        if(gameOverPanel) gameOverPanel.SetActive(false); 
        if(winPanel) winPanel.SetActive(false); 


    
    } 

    public void EndGame(bool won)
    {
        Time.timeScale = 0f; 

        if(won)
            winPanel.SetActive(true); 
        else
            gameOverPanel.SetActive(true); 

    }


    public void Restart()
    {
        Time.timeScale = 1f; 

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}