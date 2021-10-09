using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.DTO.Weather
{
    public class WeatherApiResponseDTO
    {
        [JsonProperty("location")]
        public LocationDTO Location { get; set; }

        [JsonProperty("current")]
        public CurrentDTO Current { get; set; }
    }
}
