using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class Bridge : MonoBehaviour
{

#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void SetLocation(string location);
    [DllImport("__Internal")]
    private static extern void SetWeatherAPIKey(string key);
    [DllImport("__Internal")]
    private static extern void CopyToClipboard(string text);

    public static event Action<string> OnWeatherChange;
    public static event Action IsMobile;
#endif

    
    // Start is called before the first frame update
    void Start()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
            Debug.Log("PRODUCTION: Bridge Start");
            WebGLInput.captureAllKeyboardInput = true;
            SubToEvents();
        #endif
    }

    private void SubToEvents()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
            SendLocation.OnLocationChange += (location) => SendLocationToJS(location);
        #endif
    }


    #region JS APIs
    
    public static void SendToClipboard(string text)
    {
        /*
         * Only calls the below if running in WebGL only
         */
        #if UNITY_WEBGL && !UNITY_EDITOR
            CopyToClipboard(text);
        #endif
    }
    
    public static void SendWeatherAPIKeyToJS(string key)
    {
        /*
         * Only calls the below if running in WebGL only
         */
        #if UNITY_WEBGL && !UNITY_EDITOR
            SetWeatherAPIKey(key);
        #endif
    }

    private void SendLocationToJS(string location) 
    {
        /*
         * Only calls the below if running in WebGL only
         */
        #if UNITY_WEBGL && !UNITY_EDITOR
            SetLocation(location);
        #endif
    }

    #endregion

    #region Unity APIs

    public void ChangeWeatherInUnity(string weather)
    {
        /*
         * Called from JS using unityInstance.SendMessage('Bridge', 'ChangeWeatherInUnity', 'sunny');
         */
        #if UNITY_WEBGL && !UNITY_EDITOR
            OnWeatherChange?.Invoke(weather);
        #endif
    }

    public void IsMobileDevice()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
            Debug.Log("PRODUCTION: Bridge IsMobileDevice");
            IsMobile?.Invoke();
        #endif
    }

    #endregion
    
}
