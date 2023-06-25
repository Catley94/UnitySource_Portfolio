/*
    This file is only used if game is in Development Mode.
    This mode is set within the game using compiler if statements
 */
if(!unityInstance) {
    const webSocket = new WebSocket("ws://localhost:9000/Weather");

    webSocket.onopen = (event) => {
        console.log("Web Socket Connected!");
    };

    webSocket.onmessage = (event) => {
        console.log("Message received: " + event.data);
        let json;
        try {
            json = JSON.parse(event.data);
            console.log(json);
        }
        catch (e) {
            console.error("Unable to convert to JSON: ", e);
        }
        if(json !== undefined) {
            if(json.Weather_API_Key) setWeatherAPIKey(json.Weather_API_Key);
            if(json.Location) setLocation(json.Location);
        } else {

        }
    }

    webSocket.onclose = () => {
        console.log("Web Socket Disconnected");
    }

    webSocket.onerror = () => {
        console.log("Error");
    }

    const sendMessageToServer = (message) => {
        webSocket.send(message.toString());
    }
}
