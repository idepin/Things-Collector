using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    public float duration = 300f; // Timer duration in seconds (5 minutes)
    private float timer;         // Current timer value
    private bool isTimerRunning; // Flag to check if the timer is running
    [SerializeField] private TextMeshProUGUI timerText;
    public UnityEvent onTimeOver;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                DisplayTime(timer);
            }
            else
            {
                timer = 0;
                isTimerRunning = false;
                TimerFinished();
            }
        }
    }

    // Start the timer
    public void StartTimer()
    {
        timer = duration;
        isTimerRunning = true;
    }

    // Action to perform when the timer finishes
    void TimerFinished()
    {
        Debug.Log("Time's up!");
        onTimeOver?.Invoke();

        // Add additional actions here, such as triggering events or changing the game state
    }

    // Display the timer in a readable format (optional)
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; // Adding 1 to ensure full seconds are displayed
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        string output = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.SetText(output);
    }
}
