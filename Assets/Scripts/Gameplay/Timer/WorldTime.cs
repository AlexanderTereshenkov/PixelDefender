using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WorldTime : MonoBehaviour
{
    [Tooltip("Minute duration in seconds")]
    [SerializeField] private float minuteDuration;

    [Range(0, 59)]
    [SerializeField] private int minutes;

    [Range(0, 23)]
    [SerializeField] private int hours;

    [SerializeField] private Light2D light2D;

    [SerializeField] private Gradient lightGradient;

    [SerializeField] private int startWaveHour;
    [SerializeField] private int stopWaveHour;

    private float tempSeconds;
    private bool isWaveStarted = false;
    private bool isGradientNeeded = true;

    public event Action OnTimeChaged;
    public event Action StartEnemyWave;
    public event Action StopEnemyWave;
    public event Action OnDayPassed;

    private void Start()
    {
        CalculateGradient();
    }

    private void Update()
    {
        tempSeconds += Time.deltaTime;

        if(tempSeconds >= minuteDuration)
        {
            UpdateTime();
            CalculateGradient();
            tempSeconds = 0;
        }
    }

    public string GetTime()
    {
        string time = "";
        time += (hours < 10 ? "0" + hours : hours) + ":" + (minutes < 10 ? "0" + minutes : minutes);
        return time;
    }

    public void SetIsGradientNeeded(bool value)
    {
        isGradientNeeded = value;
    }

    public Light2D GetWorldLight()
    {
        return light2D;
    }

    private void UpdateTime()
    {
        minutes++;

        if(minutes >= 60)
        {
            hours++;
            minutes = 0;
        }

        hours %= 24;

        if(hours == startWaveHour)
        {
            if (!isWaveStarted)
            {
                Debug.Log("GO");
                StartEnemyWave?.Invoke();
                isWaveStarted = true;
            }
        }
        else if(hours == stopWaveHour)
        {
            if (isWaveStarted)
            {
                StopEnemyWave?.Invoke();
                isWaveStarted = false;
                Debug.Log("STOP");
            }
            OnDayPassed?.Invoke();
        }

        OnTimeChaged?.Invoke();
    }

    private void CalculateGradient()
    {
        float percent = (hours * 60 + minutes) / 1440f;
        Color lightColor = lightGradient.Evaluate(percent);
        light2D.color = lightColor;
    }
}
