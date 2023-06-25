using System.Collections;
using System.Collections.Generic;
using DistantLands.Cozy;
using DistantLands.Cozy.Data;
using UnityEngine;

public class UpdateWeather : MonoBehaviour
{
    [SerializeField] private CozyWeather weather;
    [SerializeField] private WeatherProfile sunnyProfile;
    [SerializeField] private WeatherProfile rainProfile;
    [SerializeField] private WeatherProfile cloudyProfile;
    [SerializeField] private WeatherProfile overcastProfile;
    [SerializeField] private WeatherProfile thunderstormProfile;
    
    // Start is called before the first frame update
    void Start()
    {
        SubToEvents();
    }

    private void SubToEvents()
    {
        #if UNITY_EDITOR
            //For Development Only
            // Debug.Log("DEVELOPMENT: UpdateWeather");
            WeatherMessageService.OnWeatherChange += (weatherName) => ChangeWeather(weatherName.ToLower());
        #endif
        
        #if !UNITY_EDITOR && UNITY_WEBGL
            //For Production Only (WebGL)
            // Debug.Log("PRODUCTION: UpdateWeather");
            Bridge.OnWeatherChange += (weatherName) => ChangeWeather(weatherName.ToLower());
        #endif
    }

    private IEnumerator ChangeWeatherCoroutine(string weatherName, float delay = 0f)
    {
        yield return new WaitForSeconds(delay);
        ChangeWeather(weatherName);
    }
    
    private void ChangeWeather(string weatherName)
    {
        Debug.Log("Weather: "+ weatherName);
        switch (weatherName)
        {
            case "cloudy":
            case "partly cloudy":
                SetWeather(cloudyProfile);
                break;
            case "overcast":
                SetWeather(overcastProfile);
                break;
            case "sunny":
            case "clear":
                //TODO: Set Weather to Sunny
                SetWeather(sunnyProfile);
                break;
            case "light drizzle":
            case "light rain":
            case "heavy rain":
                SetWeather(rainProfile); 
                break;
            case "patchy light rain with thunder":
            case "moderate or heavy rain with thunder":
                SetWeather(thunderstormProfile);
                break;
            default:
                SetWeather(sunnyProfile);
                break;
        }
    }

    private void SetWeather(WeatherProfile weatherProfile)
    {
        weather.currentWeather = weatherProfile;
    }
}
