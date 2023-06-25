//Using WeatherAPI.com
//Had to make this repo private because I'm storing my APIKey here
//In Unity, ask for the API key and send it to the frontend.
const format = "json";
let weatherAPIKey = "";

const setWeatherAPIKey = (apiKey) => {
    weatherAPIKey = apiKey;
}

const setLocation = (_location) => {
    getWeatherData(_location);
}

const getWeatherData = (_location) => {
    const examplecallString = `http://api.weatherapi.com/v1/current.${format}?key=${weatherAPIKey}&q=${_location}&aqi=no`;
    axios.get(examplecallString)
        .then((response) => {
            const weatherSummary = response.data.current.condition.text;
            console.log(response);
            if(unityInstance) {
                unityInstance?.SendMessage(weatherSummary);
            } else {
                sendMessageToServer(weatherSummary);
            }
            console.log(weatherSummary);
        })
        .catch(function (error) {
            // handle error
            console.log(error);
            if(error.response.status = 400) {
                const errorMessage = "Bad Request: Please input a valid location."
                console.error(errorMessage);
                alert(errorMessage);
            }
        })
        .finally(function () {
            // always executed
        });
}



