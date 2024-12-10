﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWeatherApp.Service
{
    public class EndPoints
    {
        public const string baseUrl = "https://dataservice.accuweather.com/";
        public const string cityWeather = $"{baseUrl}currentconditions/v1/";
        public const string forecastENdpoint = $"{baseUrl}forecasts/v1/hourly/12hour/";
        public const string cityDetail = $"{baseUrl}locations/v1/cities/search?apikey=";
    }
}