using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using WebSocketSharp.Server;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class WeatherMessageService : WebSocketBehavior
{
    #if UNITY_EDITOR
    
        public static event Action<string> OnWeatherChange;

        public WeatherMessageService()
        {
            // Debug.Log("DEVELOPMENT: WeatherMessageService created");
        }
        
        protected override void OnOpen()
        {
            base.OnOpen();
            SubToEvents();
            // Debug.Log("Client connected");
            string key = WeatherAPI.GetKey();
            SendAPI(key);
        }

        private void SubToEvents()
        {
            SendLocation.OnLocationChange += OnLocationChange;
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            OnWeatherChange?.Invoke(e.Data);
        }

        private void OnLocationChange(string location)
        {
            JObject Location_Object = 
                new JObject(
                    new JProperty("Location", location)
                );
            SendMessage(Location_Object);
        }

        public void SendMessage(JObject message)
        {
            Send(message.ToString());
        }

        private void SendAPI(string api)
        {
            JObject Weather_API_Key_Object =
                new JObject(
                    new JProperty("Weather_API_Key", api)
                );
            SendMessage(Weather_API_Key_Object);
        }
#endif
}
