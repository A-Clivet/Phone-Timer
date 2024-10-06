using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManage : MonoBehaviour
{
    private Chrono _chrono;
    
    
    public void StartTimer()
    {
        _chrono._timerIsRunning = true;
    }
    
    public void ResumeTimer()
    {
        _chrono._timerIsRunning = !_chrono._timerIsRunning;
    }
}
