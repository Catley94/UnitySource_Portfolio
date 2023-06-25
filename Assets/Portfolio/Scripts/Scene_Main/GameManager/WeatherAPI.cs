using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherAPI : MonoBehaviour
{
    
    private static string Weather_API_Key = "918a5e537d1540fd865111221232105";
    
    // Start is called before the first frame update
    void Start()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
            // Debug.Log("PRODUCTION: WeatherAPI KEY: " + Weather_API_Key);
            Bridge.SendWeatherAPIKeyToJS(Weather_API_Key);
        #endif
    }

    public static string GetKey()
    {
        #if UNITY_EDITOR
            /*
             * Only used in Development Mode
             */
            return Weather_API_Key;
        #else
            /*
             * Only used in Production Mode
             */
            return "";
        #endif
    }
}
