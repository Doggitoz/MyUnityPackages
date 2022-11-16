using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float time = -1f;
    private float timerStartValue = -1f;
    private bool isRunning = false;
    private float timerScale = -1f;

    private bool _initialized = false;

    public void Init(float timerDuration, bool isTimerRunning = true, float timerScale = 1)
    {
        _initialized = true;
        this.timerStartValue = timerDuration;
        this.isRunning = isTimerRunning;
        this.timerScale = timerScale;
        Restart();
    }

    private void Start()
    {
        if(_initialized == false)
        {
            Debug.LogWarning("Timer is not initialized. Timer.Init() is required for a timer to function");
        }
    }

    void Update()
    {
        if (!isRunning || time == 0 || _initialized == false) return;

        this.time -= Time.deltaTime * this.timerScale;
        this.time = Mathf.Clamp(this.time, 0, Mathf.Infinity);
    }

    public void Restart(bool continueRunning = true)
    {
        this.time = this.timerStartValue;
        this.isRunning = continueRunning;
    }

    public void Pause()
    {
        this.isRunning = false;
    }

    public void Resume()
    {
        this.isRunning = true;
    }

    public void Stop()
    {
        this.isRunning = false;
        Restart();
    }

    public void Begin()
    {
        this.isRunning = true;
    }

    public void SetDuration(float newDuration, bool restartTimer = true)
    {
        this.timerStartValue = newDuration;
        if (restartTimer) Restart();
    }

    public bool IsRunning()
    {
        return this.isRunning;
    }

    public float RemainingTime()
    {
        return this.time;
    }

    public float GetTime()
    {
        return this.time;
    }

    public bool IsDone()
    {
        return (this.time == 0);
    }
}
