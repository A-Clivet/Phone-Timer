using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Notifications.Android;
using UnityEngine.Serialization;

public class Chrono : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI chronoUI;
    
    public static Chrono Instance;
    public bool _timerIsRunning = false;
    

    private string _timerUI;
    private float _timeRemaining = 0;
    private float _hourTimer = 0;
    private float _minuteTimer = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // _timerUI = chronoUI.text.Split(" : ");
    }

    // Update is called once per frame
    void Update()
    {
        // Si le timer est actif
        if (_timerIsRunning)
        {
            if (_timeRemaining > 0)
            {
                // Compte à rebours
                Debug.Log(_timeRemaining);
                _timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                // Si le temps est écoulé
                _timeRemaining = 0;
                _timerIsRunning = false;
                UpdateTimerDisplay();
                
                OnTimerEnd();
                
            }
        }
    }

    public void ChangeChrono(string number, bool hour)
    {
        if(hour)
        {
            _hourTimer = int.Parse(number) * 60 * 60;
        }
        else
        {
            _minuteTimer = int.Parse(number) * 60;
        }

        _timeRemaining = _minuteTimer + _hourTimer;

        UpdateTimerDisplay();
    }


    void UpdateTimerDisplay()
    {
        // Calcul des heures
        int hours = Mathf.FloorToInt(_timeRemaining / 3600);  // Diviser par 3600 pour obtenir les heures

        // Calcul des minutes restantes après avoir retiré les heures
        int minutes = Mathf.FloorToInt((_timeRemaining % 3600) / 60);  // Obtenir le reste après avoir retiré les heures, puis diviser par 60 pour obtenir les minutes

        // Afficher le timer au format HH:MM
        chronoUI.text = string.Format("{0:00}:{1:00}", hours, minutes);
    }


    void OnTimerEnd()
    {
        // couper le telephone
        AndroidSleepMode.Instance.LockScreen();
    }
}
