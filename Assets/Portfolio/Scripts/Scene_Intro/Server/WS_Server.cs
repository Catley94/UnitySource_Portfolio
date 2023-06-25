using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using WebSocketSharp.Server;

public class WS_Server : MonoBehaviour
{
#if UNITY_EDITOR
    private WebSocketServer wssv = new WebSocketServer("ws://localhost:9000");

    [SerializeField] private SOApiKey SoApiKey;
    // Start is called before the first frame update
    void Awake()
    {
        // Debug.Log("DEVELOPMENT: WS_SERVER");
        EditorApplication.playModeStateChanged += (PlayModeStateChange playMode) =>
        {
            if (playMode == PlayModeStateChange.EnteredEditMode)
            {
                wssv.Stop();
            }
        };
            
        wssv.AddWebSocketService<WeatherMessageService> ("/Weather");
        wssv.Start();
        // Debug.Log("Server started on port: 9000");
    }
#endif
}
