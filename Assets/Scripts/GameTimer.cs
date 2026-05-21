using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float timeRemaining = 600f; // 10 minutes
    private bool timerRunning = true;

    [Header("References")]
    public PointManager pointManager;
    public TMP_Text timerText;
    public TMP_Text finalPointsText;

    

    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerRunning = false;

                TimerFinished();
            }
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TimerFinished()
    {
        float finalPoints = pointManager.TotalPoint;

        Debug.Log("TIME UP!");
        Debug.Log("Final Score: " + finalPoints);
        Debug.Log("PointManager instance: " + pointManager.gameObject.name);
        Debug.Log("Score at finish: " + pointManager.TotalPoint);

        

        finalPointsText.text = $"Final Score: {pointManager.TotalPoint:0}";

    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}