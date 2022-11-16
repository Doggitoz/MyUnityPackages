using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTester : MonoBehaviour
{
    Timer testTimer;
    Timer intermediateTimer;

    private void Awake()
    {
        testTimer = this.gameObject.AddComponent<Timer>();
        testTimer.Init(15f, true);
        intermediateTimer = this.gameObject.AddComponent<Timer>();
        intermediateTimer.Init(5f, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (testTimer.GetTime() < 5f)
        {
            testTimer.Pause();
            intermediateTimer.Begin();
        }
        if (intermediateTimer.IsDone())
        {
            Debug.Log("YES");
            intermediateTimer.Restart(false);
            testTimer.Resume();
        }
        Debug.Log("testTimer: " + Mathf.Ceil(testTimer.GetTime()));
        Debug.Log("intermediateTimer: " + Mathf.Ceil(intermediateTimer.GetTime()));
    }
}
