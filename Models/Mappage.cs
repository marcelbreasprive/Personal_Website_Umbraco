
using Our.Umbraco.Ditto;
using System.Collections.Generic;
using System.ComponentModel;
using Umbraco.Core.Models;

namespace MandMOnTheRoad.Models
{
    public class Mappage : BasePage
    {
        //public virtual Image PageBanner { get; set; }
        public Mappage(IPublishedContent content) : base(content) {}

        [TypeConverter(typeof(DittoPickerConverter))]
        [UmbracoProperty("MapLocations")]
        public virtual Map Map { get; set; }
    }
}