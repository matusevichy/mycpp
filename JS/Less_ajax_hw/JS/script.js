getPosition();


function getPosition(){
    if ("geolocation" in navigator) {
        console.log("Navigator Ok");
        navigator.geolocation.getCurrentPosition(function (pos) {
            getWeather(pos.coords.latitude, pos.coords.longitude);
        }, (err) => {
            console.log(err.code, err.message)
        })
    }
    else
    {
        console.log("Geolocation error");
    }
}

async function getWeather(lat, long){
    const url = `http://api.openweathermap.org/data/2.5/weather?lat=${lat}&lon=${long}&units=metric&lang=ua&APPID=cac13560ea6c07b4b6faca1ca6a6c115`;
    try{
        const response= await fetch(url);
        const json = await response.json();
        if(json["cod"] === 200)
        {
            showWeather(json);
        }
        else
        {
            console.log(json["cod"], json["message"]);
        }
    }
    catch(err){
        console.log(err)
    }
}

function showWeather(data){
    const weather = document.body.querySelector('#weather');
    const weatherItem = document.createElement('div');
    weatherItem.id="weather-item";
    const date = document.createElement('p');
    date.innerHTML = new Date().toLocaleString();
    const city = document.createElement('h3');
    city.innerHTML = data['name'];
    const img = document.createElement('img');
    img.src=`https://openweathermap.org/img/wn/${data['weather'][0]['icon']}@2x.png`;
    const imgDescr = document.createElement('span');
    imgDescr.innerHTML = data['weather'][0]['description'];
    const temp = document.createElement('div');
    temp.id = "temp";
    temp.innerHTML = (data['main']['temp'] > 0)? `+ ${(data['main']['temp']).toFixed(1)}` : (data['main']['temp']).toFixed(1);
    const feelsLike = document.createElement('div');
    feelsLike.innerHTML = "Відчувається ";
    feelsLike.innerHTML += (data['main']['feels_like'] >0)?`+ ${data['main']['feels_like'].toFixed(1)}`: data['main']['feels_like'].toFixed(1);
    const otherBlock = document.createElement('div');
    otherBlock.id = "other-block";
    const wind = document.createElement('div');
    wind.innerHTML = `Вітер <span>${data['wind']['speed']} м/с</span>`;
    const pressure = document.createElement('div');
    pressure.innerHTML = `Тиск <span>${Math.round(data['main']['pressure']/1.33)} мм рт.ст.</span>`;
    const humidity = document.createElement('div');
    humidity.innerHTML = `Вологість <span>${data['main']['humidity']} %</span>`;

    otherBlock.append(wind, pressure, humidity);
    weatherItem.append(city, date, temp, feelsLike, img, imgDescr, otherBlock);
    weather.append(weatherItem);
}
