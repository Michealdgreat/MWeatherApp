using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MWeatherApp.MVVM.Models.DailyForecastModel;

namespace MWeatherApp.MVVM.Models
{
    public class DailyForecast
    {
        public DateTime Date { get; set; }
        public long EpochDate { get; set; }
        public DailyForecastModel.Temperature? Temperature { get; set; }
        public DayNight? Day { get; set; }
        public DayNight? Night { get; set; }
        public List<string>? Sources { get; set; }
        public string? MobileLink { get; set; }
        public string? Link { get; set; }
    }
}
