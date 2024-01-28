using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    public TextMeshProUGUI timerText;
    private float startTime;
    public float elapsedTime;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (!LevelManager.instance.isOver)
        {
            elapsedTime = Time.time - startTime;
            UpdateTimerText(elapsedTime);
        }
    }

    void UpdateTimerText(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

        timerText.text = "Time: " + timerString;
    }

}
