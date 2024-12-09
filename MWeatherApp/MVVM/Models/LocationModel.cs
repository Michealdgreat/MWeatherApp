using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWeatherApp.MVVM.Models
{
    public class LocationModel
    {
        public int Version { get; set; }
        public string? Key { get; set; }
        public string? Type { get; set; }
        public int? Rank { get; set; }
        public string? LocalizedName { get; set; }
        public string? EnglishName { get; set; }
        public Region? Region { get; set; }
        public Country? Country { get; set; }

        public GeoPosition? GeoPosition { get; set; }

        public ParentCity? ParentCity { get; set; }

    }

}
