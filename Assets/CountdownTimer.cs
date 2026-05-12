using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 60f; // change this whenever you want
    public TextMeshProUGUI timerText;

    public float warningTime = 10f;
    private bool timerRunning = true;



    // Update is called once per frame
    void Start()
    {
        timerText.color = Color.white;
    }
    void Update()
    {   


        if (!timerRunning) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            timerRunning = false;
            UpdateTimerDisplay(0);
            FindObjectOfType<GameManager>().EndGame(false);
        }
    }

    void UpdateTimerDisplay(float time)
    {
        // Formats it as  0:60, 0:59, 0:58 etc.
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

     void UpdateTimerColor(float time)
    {
        if (time <= warningTime)
            timerText.color = Color.red;
        else
            timerText.color = Color.white;
    }
}
