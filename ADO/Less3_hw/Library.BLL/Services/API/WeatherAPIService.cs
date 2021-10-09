using Library.BLL.DTO.Weather;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Services.API
{
    public class WeatherAPIService
    {
        const string API_URL = "https://api.weatherapi.com/v1";
        const string API_KEY = "e33a93a951f84fb2b9185444202911";
        public WeatherApiResponseDTO GetWeatherForCity(string city)
        {
            var client = new RestClient(API_URL);
            var request = new RestRequest("current.json", DataFormat.Json)
                .AddParameter("key", API_KEY)
                .AddParameter("q", city)
                .AddParameter("aqi", "no");
            var content = client.Get(request).Content;
            var responseDto = JsonConvert.DeserializeObject<WeatherApiResponseDTO>(content);
            return responseDto;
        }
    }
}
