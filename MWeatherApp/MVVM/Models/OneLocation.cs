using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWeatherApp.MVVM.Models
{
    public class OneLocation
    {
        public DateTimeOffset LocalObservationDateTime { get; set; }
        public long EpochTime { get; set; }
        public string? WeatherText { get; set; }
        public int WeatherIcon { get; set; }
        public bool HasPrecipitation { get; set; }
        public string? PrecipitationType { get; set; }
        public bool IsDayTime { get; set; }
        public TemperatureValue? Temperature { get; set; }
        public string? MobileLink { get; set; }
    }
}
