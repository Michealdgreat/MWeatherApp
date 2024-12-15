using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWeatherApp.MVVM.Models
{
    public class DailyForecastModel
    {

        public class Headline
        {
            public DateTime EffectiveDate { get; set; }
            public long EffectiveEpochDate { get; set; }
            public int Severity { get; set; }
            public string? Text { get; set; }
            public string? Category { get; set; }
            public DateTime EndDate { get; set; }
            public long EndEpochDate { get; set; }
            public string? MobileLink { get; set; }
            public string? Link { get; set; }
        }

        public class TemperatureDetail
        {
            public double Value { get; set; }
            public string? Unit { get; set; }
            public int UnitType { get; set; }
        }

        public class Temperature
        {
            public TemperatureDetail? Minimum { get; set; }
            public TemperatureDetail? Maximum { get; set; }
        }

        public class DayNight
        {
            public int Icon { get; set; }
            public string? IconPhrase { get; set; }
            public bool HasPrecipitation { get; set; }
            public string? PrecipitationType { get; set; }
            public string? PrecipitationIntensity { get; set; }
        }

        public class WeatherForecast
        {
            public Headline? Headline { get; set; }
            public ObservableCollection<DailyForecast>? DailyForecasts { get; set; }
        }

    }
}
