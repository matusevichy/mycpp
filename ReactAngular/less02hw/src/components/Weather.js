import React from "react";

export default class Weather extends React.Component{
    constructor(props) {
        super(props);
        this.state = {
            date:new Date(),
            json:''
        }
    }
    componentDidMount() {
        let lat = 0;
        let long = 0;
        if ("geolocation" in navigator) {
            console.log("Navigator Ok");
            navigator.geolocation.getCurrentPosition(function (pos) {
                lat = pos.coords.latitude;
                long = pos.coords.longitude;
            }, (err) => {
                console.log(err.code, err.message)
            })
        }
        else
        {
            console.log("Geolocation error");
        }
        setTimeout(() => {
            const url = `http://api.openweathermap.org/data/2.5/weather?lat=${lat}&lon=${long}&units=metric&lang=ua&APPID=cac13560ea6c07b4b6faca1ca6a6c115`;
            fetch(url).then(response => response.json()).then(json => this.setState({json}));
        }, 10)
    }

    render() {
        const weather = this.state.json;
        return (
            <div className="weather">
                <div>
                    <p className="date">{this.state.date.toLocaleDateString()}</p>
                    <h3 className="city">{weather['name']}</h3>
                    <img className="img" src={`https://openweathermap.org/img/wn/${weather['weather']?.[0]['icon']}@2x.png`} />
                    <p className="img-descr">{weather['weather']?.[0]['description']}</p>
                    <div className="temp">{(weather['main']?.['temp'] > 0)? `+`+ (weather['main']?.['temp'])?.toFixed(1) : (weather['main']?.['temp'])?.toFixed(1)}</div>
                    <div className="feelslike">Відчувається {(weather['main']?.['feels_like'] >0)?`+ ${weather['main']?.['feels_like'].toFixed(1)}`: weather['main']?.['feels_like'].toFixed(1)}</div>
                    <div className="other">
                        <div className="wind">Вітер <span>{weather['wind']?.['speed']} м/с</span></div>
                        <div className="pressure">Тиск <span>{Math.round(weather['main']?.['pressure']/1.33)} мм рт.ст.</span></div>
                        <div className="humidity">Вологість <span>{weather['main']?.['humidity']} %</span></div>
                    </div>
                </div>
            </div>
        )
    }

}
