using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class Chrono : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI chronoUI;
    
    public static Chrono Instance;

    private string[] _timerUI;
    private float _timer = 0;
    

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
        _timerUI = chronoUI.text.Split(" : ");
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > 0)
        {
            // Réduire le temps avec deltaTime
            //timer -= Time.deltaTime;
            
            // Affiche le temps restant
            _timerUI[0] = (_timer%3600).ToString("F0");
            _timerUI[1] = (_timer%60).ToString("F0");

        }
        else
        {
           // couper le telephone
        }
    }

    public void ChangeChrono(string number, bool hour)
    {
        if (int.Parse(number) < 10)
        {
            number = "0" + number;
        }
        
        
        if (hour)
        {
            _timerUI[0] = number;
        }
        else
        {
            _timerUI[1] = number;
        }

        chronoUI.text = _timerUI[0] + " : " + _timerUI[1];
        
        _timer = float.Parse(_timerUI[1]) * 60 + float.Parse(_timerUI[0]) * 60 * 60;
    }
    

    public void StartTimer()
    {
        //StartCoroutine(Timer());
    }

    // IEnumerator Timer()
    // {
    //     yield return new WaitForSeconds(timer);
    // }
}
