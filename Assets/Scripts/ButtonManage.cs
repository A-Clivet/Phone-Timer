using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManage : MonoBehaviour
{
    public void StartTimer()
    {
        Chrono.Instance._timerIsRunning = true;
    }
    
    public void ResumeTimer()
    {
        Chrono.Instance._timerIsRunning = !Chrono.Instance._timerIsRunning;
    }
}
