
using Our.Umbraco.Ditto;
using System.Collections.Generic;
using System.ComponentModel;
using Umbraco.Core.Models;

namespace MandMOnTheRoad.Models
{
    public class Homepage : BasePage
    {
        //public virtual Image PageBanner { get; set; }
        public Homepage(IPublishedContent content) : base(content) {}

        public virtual Image PageBanner { get; set; }

        [UmbracoProperty("googleAPIKey")]
        public virtual string GoogleAPIKey { get; set; }

        [TypeConverter(typeof(DittoPickerConverter))]
        [UmbracoProperty("TimelineFolder")]
        public virtual TimeLine TimeLine { get; set; }

        [TypeConverter(typeof(DittoPickerConverter))]
        [UmbracoProperty("MapLocations")]
        public virtual Map Map { get; set; }
    }
}