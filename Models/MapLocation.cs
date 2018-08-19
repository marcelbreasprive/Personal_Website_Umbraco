using Newtonsoft.Json;
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
    public class MapLocation : PublishedContentModel
    {
        public MapLocation(IPublishedContent content) : base(content) { }

        public virtual string Title { get; set; }

        public virtual string ShortDescription { get; set; }

        public virtual string Location { get; set; }


        private GeoLocation _geoLocatie;

        [DittoIgnore]
        public GeoLocation GeoLocatie {
            get {
                if(_geoLocatie == null)
                    _geoLocatie = JsonConvert.DeserializeObject<GeoLocation>(Location);

                return _geoLocatie;
            }
        }


        
    }
}