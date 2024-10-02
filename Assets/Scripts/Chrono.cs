using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chrono : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _chronoUI;
    
    public static Chrono Instance;

    private string[] timerUI;
    private float timer = 0;
    

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
        timerUI = _chronoUI.text.Split(" : ");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            // Réduire le temps avec deltaTime
            //timer -= Time.deltaTime;
            
            // Affiche le temps restant
            timerUI[0] = (timer%3600).ToString("F0");
            timerUI[1] = (timer%60).ToString("F0");

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
            timerUI[0] = number;
        }
        else
        {
            timerUI[1] = number;
        }

        _chronoUI.text = timerUI[0] + " : " + timerUI[1];
        
        timer = float.Parse(timerUI[1]) * 60 + float.Parse(timerUI[0]) * 60 * 60;
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
