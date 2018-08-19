using Our.Umbraco.Ditto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace MandMOnTheRoad.Models
{
    [TypeConverter(typeof(DittoPickerConverter))]
    public class Map : PublishedContentModel
    {
        public Map(IPublishedContent content) : base(content) { }

        [TypeConverter(typeof(DittoPickerConverter))]
        [UmbracoProperty("Children")]
        public virtual IEnumerable<MapLocation> Locations { get; set; }

        public string GetGoogleCoordinates(string jsvariable)
        {
            if (Locations == null || !Locations.Any())
             return string.Format("var {0} = [];", jsvariable);

            var locationstring = string.Format("var {0} = [", jsvariable);
            foreach (var item in Locations)
            {
                if(!string.IsNullOrEmpty(item.Location))
                    locationstring += string.Format("{{ lat:{0}, lng:{1}, title: '{2}', shortdescription: '{3}' }},", item.GeoLocatie.Latitude, item.GeoLocatie.Longitude, HttpUtility.JavaScriptStringEncode(item.Title), HttpUtility.JavaScriptStringEncode(item.ShortDescription.Replace("\n", "<br />")));
            }

            locationstring = locationstring.Substring(0, locationstring.Length - 1);
            locationstring += "];";

            return locationstring;
        }
    }
}
