using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWeatherApp.MVVM.Models
{
    public class WeatherForecastModel
    {
        public DateTimeOffset DateTime { get; set; }
        public long EpochDateTime { get; set; }
        public int WeatherIcon { get; set; }
        public string? IconPhrase { get; set; }
        public bool HasPrecipitation { get; set; }
        public bool IsDaylight { get; set; }
        public Temperature? Temperature { get; set; }
        public int PrecipitationProbability { get; set; }
        public string? MobileLink { get; set; }
        public string? Link { get; set; }


    }
}
