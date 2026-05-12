using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro;


public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel; 
    public GameObject winPanel;

    public GameObject timerUI;     
    public GameObject flashlightIcon;
    public TextMeshProUGUI bestTimeText;
    public TextMeshProUGUI currentTimeText;


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


        if (won)
        {
            //highscore tracking
            CountdownTimer timer = FindObjectOfType<CountdownTimer>();
            float timeTaken = timer != null ? timer.TimeTaken : 0f;

            // Load previous best (default to max value if none saved)
            float bestTime = PlayerPrefs.GetFloat("BestTime", float.MaxValue);

            // Update best if this run was faster
            if (timeTaken < bestTime)
            {
                bestTime = timeTaken;
                PlayerPrefs.SetFloat("BestTime", bestTime);
                PlayerPrefs.Save();
            }

            // Display on win panel
            if (currentTimeText != null)
                currentTimeText.text = "Your Time: " + FormatTime(timeTaken);

            if (bestTimeText != null)
            {
                if (bestTime == float.MaxValue)
                    bestTimeText.text = "Best Time: --";
                else
                    bestTimeText.text = "Best Time: " + FormatTime(bestTime);
            }
                winPanel.SetActive(true); 
            }
        else
        {
            gameOverPanel.SetActive(true); 
        }
    }

    string FormatTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:0}:{1:00}", minutes, seconds);
    }
    


    public void Restart()
    {
        Time.timeScale = 1f; 

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("StartScreen"); // make sure this matches your scene name exactly
    }
}