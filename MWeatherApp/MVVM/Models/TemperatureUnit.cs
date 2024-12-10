using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWeatherApp.MVVM.Models
{
    public class TemperatureValue
    {
        public TemperatureUnit? Metric { get; set; }
        public TemperatureUnit? Imperial { get; set; }
    }

    public class TemperatureUnit
    {
        public double Value { get; set; }
        public string? Unit { get; set; }
        public int UnitType { get; set; }
    }
}
