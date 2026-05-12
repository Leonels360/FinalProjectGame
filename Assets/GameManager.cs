using UnityEngine;
using UnityEngine.SceneManagement; 


public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel; 
    public GameObject winPanel;

    public GameObject timerUI;     
    public GameObject flashlightIcon;


    void Start()
    {
        Time.timeScale = 1f; 

        if(gameOverPanel) gameOverPanel.SetActive(false); 
        if(winPanel) winPanel.SetActive(false); 


    
    } 

    public void EndGame(bool won)
    {
        Time.timeScale = 0f; 
        //makes the cursor visible again
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //hide UI on game end
        if (timerUI != null) timerUI.SetActive(false);
        if (flashlightIcon != null) flashlightIcon.SetActive(false);


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