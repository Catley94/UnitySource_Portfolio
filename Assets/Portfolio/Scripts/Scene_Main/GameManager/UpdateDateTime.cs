using System;
using System.Collections;
using System.Collections.Generic;
using DistantLands.Cozy;
using UnityEngine;

public class UpdateDateTime : MonoBehaviour
{
    [SerializeField] private CozyWeather weather; 
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateTimeAndDate();
    }

    private void UpdateTimeAndDate()
    {
        UpdateDate();
        UpdateTime();
    }

    private void UpdateDate()
    {
        int year = DateTime.Now.Year;
        weather.currentYear = year;
    }

    private void UpdateTime()
    {
        int hour = DateTime.Now.Hour > 12 ? DateTime.Now.Hour - 12 : DateTime.Now.Hour;
        int minute = DateTime.Now.Minute;
        MeridiemTime.Meridiem meridiem = DateTime.Now.Hour > 12 ? MeridiemTime.Meridiem.PM : MeridiemTime.Meridiem.AM;
        MeridiemTime time = new MeridiemTime(hour, minute, meridiem);
        weather.currentTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
